---
layout: post
title: Exceptions are the norm!
public: false
author: giacomo
---

This year has been quite challenging. I've worked on a brand-new domain model
for an italian online bank, offering financial advice through different channels
(phone, web, personal contact) in the context of the MiFID european directive.

The domain has been split in seven different bounded contexts, designed during
the first six months of the year but still under tuning due to both change
requests and deeper insights.

The full application consists of 29 .NET solutions, 111 projects of different
types developed in 11 months by an average of nine developers (not counting the
effort by the KAM, the project manager and the third parties).

We faced a lot of challenges, both technical and organizational and everybody
have learned a lot in the process.

To me, one of the most surprising lesson that I learned the hard way, is about
the meaning of exceptions and how they work in DDD projects.

Let's start with some definitions from common sense.

Failure 
------- 
A system "[fails][1]" whenever it does not behave as **designed**.

This definition applies to any system, but it is still useful to draw knowledge
for information technology. For example we can see how any failure can be either
negative or positive according to the specific point of view of those who hits
it. A weapon that fail to kill a person (any person!), is not a failure at all.
And we all know how developers tend to sell all unexpected software's behaviours
as brand new features whenever they can find even only one condition when the
behavior actually benefits at least one observer.

But a simple consideration move us forward: software is just a tools to make
hardware useful to humans. Operating systems provide us simple and reliable
abstractions like files, processes and so on, but even the best driver can't
make the software completely safe because any hardware device, ultimately, [can
break][2]. Moreover, we know that humans are [guilty by design][3]: we can't
trust them blindly or the system will rapidly become a [garbage dispatcher][4].

Let's take a simple program designed to execute a simple task: show to the user
the content of a file (a sort of really simplified [cat][5]). The program should
just take the file's path provided from the user as an argument, ask the OS for
its content and print it to the standard output. Pretty simple!

Now answer to this questions: what's the right thing that the OS should do if it
can't read the file due to a broken sector in the disk? what's the right thing
to do if it can't read the file due to a broken RAM block that corrupted the
[inode pointer structure][6]? what's the right thing to do if it can't read the
file because it simply does not exist?

A number of (funny) options come to mind: 

1. open and returns the contents of the file with the most similar path of the 
   requested one, according to a smart algorithm carefully designed 
   by the kernel hackers 
2. open and returns the contents of a random file in the filesystem 
3. beat around the bush, blocking the caller 'till the end of times (after all, 
   why the hell should the OS admit that it can't comply the contract, 
   returning the file content? why admit such a misconduct?) 
4. inform to the caller about the problem occurred.

The first three options actually eases the application developer's life: he
doesn't need to check for error codes and/or exceptions, he can just open the
file read the content and print it out. I'm quite sure that at least a man from
marketing exists that could describe such behaviours as an innovative feature! :-)

Unfortunately, even [the most advanced operating system][9] I know of, still
adopts the forth, boring, approach. It **replies** to the caller, "sorry, I
can't fulfil your request". It can be a -1 value returned by an [open][7] or one
of the [IOExceptions][8] designed by Microsoft, but any serious operating
system's API informs the caller whenever it fails to fulfil a request.

Such a boring pattern doesn't come from smart engineers, it's spread in real
life: whenever my wife tell me to clean the kitchen, I **reply** that I have to
do something more important (say, play Mahjong with my daughter) so I can't
actually fulfil her request.  
Then, most of times, she starts polling.  
Why can't I block the caller till the end of the game?  
Simply because, as an husband, I'm **designed** to help my wife.

Let's look at it deeper: the forth, boring, solution is actually a devilish trick!
By **designing** the computation so that it can fail, it can not fail anymore!

Indeed, the failure becomes one of the possible response of the computation, 
thus, by the definition of failure, it's no more a misbehaviour!  
It becomes a carefully designed behaviour, like the succesful one.

Exceptions are responses like other 
-----------------------------------
Face it, every computation from real world can fail.   
The simplest computation that I can think of, the sum of two integers, can overflow.

In plain old procedural languages like C, [special return values][10] have been
used to express the impossibility to perform the desired computation. 
Functional languages build [disjoint unions][11] upon higher level abstractions 
(see for example the `Either a` monad in Haskell). 

Thus both C and Haskell programmers are used to handle _all_ return values, both 
successful and exceptional ones.

OOP introduced [exceptions][10] but only with Java we got the static check of
exceptions that enforces to handle exceptional conditions.

This looks a bit strange.

After all, no-one would dream to ignore the other possible results of a sum!  

Nobody takes into account an algebraic library that crashes when it compute, say, 42! 
Why should an exception be different from 42?

A twofold question 
------------------
We have found that whenever we handle exceptional conditions that occur at
runtime, they stop to be failures and become results among others.

That sounds good, since a software without failures is definitely **reliable**.

However, being the exceptional paths so frequent in
sofware development, they are **expensive** to design and handle.

We are lazy, you know. At the very end, in the deep of our soul, we still
believe that programming should just be funny. We play, while programming. The
exceptional paths take time to be analyzed and handled, while most of times we
want to concentrate on those exciting new things that give us that feeling to be
smart (not to mention details like paying the bills in a competitive
environment).

Thus, sometimes, we write software that is just reliable enough for our current 
purpose. And that's fine! We can also sell unreliable software when the customer
doesn't want to pay for reliability.

In a [very interesting article][12] about monadic exceptions handling in F#, Luca Bolognese 
defines unreliable applications as "normal" and reliable ones as "critical".

I don't agree with such definition because "normal" is a vague concept without
a clear definition of the population. I've wrote tons of useful but unreliable
scripts in my life: they are "normal" among throwaway scripts, but I would not 
sell such scripts to anyone!

Moreover he distinguish between "successful code paths", "contingencies" and 
"faults" but again I don't agree with him. I've seen [similar classifications][13] 
before, but even the [best analysis][14] that I've found, mixes independent axes.

I don't think that an API designer can guess if the exceptional conditions that
he encountered are critical to the consumer or not. 
After all, why a missing file should be critical? I will survive, after all.  
Unless it is a shared library that a robot requires to stich up my heart.

It's the consumer that must decide how to use the computation results, even 
exceptional ones. Note that this is true for the user himself: he can be
despaired of a 404 http response or simply go back to google. 
Still, the http server didn't fail, it just replied (in a protocol designed to be reliable).

Reliability: a feature like other
---------------------------------
A reliable application doesn't fail, by design. It handle properly all 
exceptional conditions that can occur.  
In these months I have carefully designed a lot of expressive exceptions 
that enforce business rules of the domain model I wrote.
Without checked exceptions, I had to manually keep track of each exception 
thrown and each exception forwarded by each method. It was a pain.

On the other hand an unreliable software can fail. 
Since there's no such thing like a free lunch, you can't have 
a reliable application but pay for unreliable one.

This makes prototypes... well, just prototypes!

Nevertheless a lot of successful applications are unreliable. And still [successful][15].
This happens because reliability is just a feature like any other.

What make an unhandled exception critical is the trust that the user has in the 
application. If he truly rely on the application for its own business, he will
pay for reliability, otherwise he will not.

In a nutshell
-------------
All this analysis lead me to this conclusions:
* every single computation can fail
* every computation becomes reliable when we include failures among its responses
* exceptions are just one way to express such failures (with a nice syntax that
  helps us to focus on the successful code path that we all love)
* hiding exceptional conditions that can occur is always an expensive **API design bug** 
  that makes the API itself and any direct or indirect consumer unreliable
* there are no such things as errors or critical exceptions
* there are reliable applications with bugs (unhandled exceptions)
* there are unreliable applications that crash (but it's fine if everybody 
  know that such crashes are a well known feature).

Rewording Bolognese:

> The .NET framework decided to allow developers to hide and/or ignore
> some of the possible results of every computation. It organized such
> hidable/ignorable results in a class hierarchy rooted at `System.Exception`.
> By doing so, it makes it easier to write **unreliable** apps, 
> but more difficult to write **reliable** apps.

I've found such a pain in the Exception handling of .NET that I considered 
to move out.  
However, right now, I'm designing a tool to improve such a poor exception 
handling. Such a tool will be included in Epic when ready. 

I'm not here to say that Java checked exceptions are perfect and I really 
know all the issues with them. However, when you have to write a reliable 
domain model that grants aggregates' consistency, C# becomes a pain.

And IMHO, this is due to misconceptions about what an exception ultimately is: 
simply one of the possible responses to a computational request.


[1]: http://en.wikipedia.org/wiki/Failure
[2]: http://pages.cs.wisc.edu/~kadav/papers/carb-sosp09.pdf
[3]: http://en.wikipedia.org/wiki/Original_sin 
[4]: http://en.wikipedia.org/wiki/Garbage_in,_garbage_out
[5]: http://linux.die.net/man/1/cat
[6]: http://en.wikipedia.org/wiki/Inode_pointer_structure
[7]: http://linux.die.net/man/3/open
[8]: http://msdn.microsoft.com/it-it/library/system.io.ioexception(v=vs.100).aspx
[9]: http://plan9.bell-labs.com/plan9/
[10]: http://en.wikibooks.org/wiki/C_Programming/Error_handling
[11]: http://en.wikipedia.org/wiki/Disjoint_union
[12]: http://lucabolognese.wordpress.com/2012/11/19/exceptions-vs-return-values-to-represent-errors-in-f-i-conceptual-view/
[13]: http://blogs.msdn.com/b/ericlippert/archive/2008/09/10/vexing-exceptions.aspx
[14]: http://www.haskell.org/haskellwiki/Error_vs._Exception
[15]: http://upload.wikimedia.org/wikipedia/en/d/de/Failwhale.png
