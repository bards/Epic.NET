---
layout: post
title: DDD Day, the smartest question
public: true
---
Saturday, during the latest Greg's session, [Arialdo Martini][arialdo] asked a 
very smart question.

> Why should the domain expert explain to me the problem?  
> He's an expert! He should explain to me the solution!

When I tried to answer (very rapidly) I noted that I wasn't able to explain my 
point of view with the depth that the question required.

However, IMHO, it was probably one of the most valuable question of the meeting.

The "problem"
-------------
I think that we have to explicitly define the term "problem".

Softwares have to solve problems. To be precise, they have to solve 
problems that are more expensive than those they create.  
This is quite obvious.

An enterprise software should solve a problem of the company that buy it.

Now, when you start to develop a software that will be part of a corporate's 
process you will note that you have to understand the existing process (and its
problems) to interact with it.  
Indeed, if the customer had no problem, why should he buy a new software?

The customer's problem could be a new law that imposes him to change his 
processes. Or he might want to optimize an aspect of it. Or he might need a 
software that is designed for his own brand-new company.

In any case you have to talk with the customer to understand why he need you.

The "matter"
------------
Once you know why he needs you, you have to understand how to help him.

That's where a domain model can help. 

We are developers, focused on scalability issues, nasty networking problems and 
the so. We are so good with these complex things that we loose the simple reason 
why we do them. At the end of the day, it's just a matter of making life easier 
to someone. 
According to who is the beneficiary, our work helps the goods or the evils. 
But if it helps no one, we can't eke out a living.

We need a domain model to reduce the risk of making a performant, scalable 
software... that no one need.

Enter the domain expert 
-----------------------
You have to help your customer. Sometimes he knows what he need.

Looking for a faster database? Try PostgreSQL. Not enough? Denormalize it!  
Looking for a WSDL service? What's simpler?  
Looking for a bitch? Mmmm... where I can find a bitch?

The point is that assuming that our customer doesn't know what he need is a bit 
arrogant. If he has a problem that he doesn't know how to solve, he will 
probably ask to someone else. He will ask to the experts in the matter of his 
problem.   
We are just **programming** whores (with a dignity? I don't know...). 

In some occasion he need a software tool for an operative process of his company.
Improving the process is the customer's problem, the process itself is the 
matter. The "domain".

You need a domain expert to understand such a process.

As Greg pointed out, DDD shines when the matter has not yet been formalized in 
a well defined language. In such a case you often need at least two domain 
experts (and high social skills! :-D).

Declarative domain models?
--------------------------
If I can remember, in my answer to Arialdo, I cited functional programming.

Functional programming lead you to describe the problem, instead of the solution.
If you know Haskell or Lisp you know what I mean.
(I also cited HTML and XML, but it was confusing, I should have cite XSLT!)

However the point is not the programming paradigm you adopt.

It's a rule of thumb: if you are truly able to describe a problem, you solved it.
In other words, [complex problems are simple solutions behind misunderstood details][tesio].

In a domain driven application most of the value is not in the technological 
knowledge of the developers, it's in their understanding of the matter.

That's why I'm building Epic: to wipe out the impact of technology on the
domain knowledge.

C# is just a language (with pros and cons) that is formal enough to cleanly 
fix such knowledge in code (and that is diffused enough to "cheaply" find 
smart developers that can think in it).

Thus, when Epic will be completed, our models will be a runnable description 
of our domain's understanding. 

However, even without Epic, we found very useful
to build declarative domain models. Even if they are coupled with a technology
that you master, they still keep your understanding of the problem inside.
Reading it later you will be able to understand why you did things in that way
(if you document the design decisions taken to workaround technological 
limitations).


[arialdo]: http://arialdomartini.wordpress.com/
[tesio]: http://www.tesio.it/
