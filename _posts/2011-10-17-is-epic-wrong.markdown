---
layout: post
title: Is Epic wrong?
public: true
---
<a name="detail-fn-back"></a>
During the latest Greg's session at the DDD Day I candidly stated that
"CQRS/ES are implementation [details][detail-fn]". This inadvertently moved the
session to a bizarre situation where Greg tried to explain me that it is not
possible to use the same code with a database storage and with event sourcing
while I kept to state that it's possible.

It was bizarre, just because of my english. :-D

But it was funny, too. After the session, we talked a bit more, with the help
of patient translators, but still he didn't convince me.

The point is relevant to me because Epic's architecture is based on the
postulate that it is always possible to keep the business
rules completely clean from the technological environment that run them.

<a name="arc-fn-back"></a>
The first (most important) reason is that, being
an [architect][arc-fn], I look at things from the customer's perspective.
He doesn't want to know how you build things, as far as they solve his
own problems.
I think he would appreciate if you sell him a codebase
that **any (serious) developer** can understand and maintain.
Indeed, this aspect would decouple his company from your fate.
Binding the customer to your fate (either through bugs or a complicated
source code), means hiding him an heavy cost.
Thus, the technologies and techniques that we adopt **should** always
be a detail.

The fact that such details are so expensive, is just an evidence of the
earliness of our tools. (and this is the issue that Epic addresses)

The value in the language
-------------------------
The second reason is more related to DDD: I think that we all agree that the
most important product of Evan's principles is the definition of an
**ubiquitous language**, shared between experts, developers and users.

But why it's so important to share a common language? Obvious, to fidelize
customers!

Binding the knowledge in a simple OO code is important to ease comunication 
with the customer that, occasionally, ask "I did A, B and C, why I've got E 
instead of D?". Thanks to fast answers in the right language, our customers 
keep asking new modules (or even to replace old legacy software). 
This creates a virtuos circle that makes us earn more.

On the contrary, when we can't answer fastly (and certainly) to such questions 
becouse of technicalities, we lose a bit of trust (thus money).

Bla bla bla... show me the code!
--------------------------------
To my programmer's heart, you won, Greg. Really.   
I have very few [LoC][epic-code] to show.

Moreover, to my entrepreneurial eye, you gave me a (potential)
unespected, unfair and huge competitive advantage. Thus I wondered for a
while if I should prove I'm right, or not.

Don't get me wrong: your words weigh a lot. If you are right, I lost more than
a year, following a wrong vision. But if you are not, your authority
can keep my competitors out of the way.

If I'm right, I would pay to get you to state that Epic is just
"programming pornography"! ;-)

So what?
--------
I think that we agree that we can persists entities
like the [Cargo][cargo], the [Location][location] and the [Voyage][voyage]
that are present in the simplified [domain][dddsample] I distribute with
Epic on a database (sql or not, is another detail).

Look at the code: it has properties (with getters), it has fields, it has
(almost) the typical structure that state storages persist.

Now, let's bet
--------------
If I can prove you, by describing the components' interactions of an
application that it is possible to use such model in an CQRS or ES fashion
you'll work for Epic for one week, full time, for free (5 days, 7 hours a day, 
remotely).

If you'll prove me that my vision is wrong, I'll do the same for you.

(we will find a gentleman's agreement on when the loser will pay the bet... :-D)

Why?
----
I know, it's a risky bet.
I've always known that Epic is very ambitious, but I still think it's possible!

However I'm probably wrong: I miss your varied experience.
Even if the patterns described in the manual don't lose their value,
ceasing Epic's development, after all the work I did, would be shaming.

And btw my wife will never allow me to start an open source project again! :-D

But that's life! I've done other errors in the past, and I've never fled them.

<div class="footnotes" style="display:block; font-size:small;
padding-top:20px;">
<p>[1 <a name="detail-fn" href="#detail-fn-back">^</a>] I'm used to work
with large projects, that fill up months of different teams.
In such context, as an architect, I'm used to define "detail"
something that requires a predictable amount of time and
does not produce interdependencies between developers.
Indeed through a correct separation of concerns, we can parallelize activities
that have no dependencies (or depend on <u>already</u> shared contracts).
The only changes that we can't control are those in the customer's mind.</p>

<p>[2 <a name="arc-fn" href="#arc-fn-back">^</a>] If
<a href="/2011/06/29/software-architecture.html">architecture</a> is
the structure that allows an artifact to satisfy the <u>paid</u> requirements,
an architect is someone able to get a clean vision of the artifact far before
it's actually built. This way he can drive the development.</p>
</div>

[detail-fn]: #detail-fn "What is an implementation detail?"
[arc-fn]: #arc-fn "Who is an Architect?"
[architecture]: http://epic.tesio.it/2011/06/29/software-architecture.html
[cargo]: https://github.com/Shamar/Epic.NET/blob/devel/Challenges/Challenge00.DDDSample/Challenge00.DDDSample.Default/Cargo/Cargo.cs
[location]: https://github.com/Shamar/Epic.NET/blob/devel/Challenges/Challenge00.DDDSample/Challenge00.DDDSample.Default/Location/Location.cs
[voyage]: https://github.com/Shamar/Epic.NET/blob/devel/Challenges/Challenge00.DDDSample/Challenge00.DDDSample.Default/Voyage/Voyage.cs
[dddsample]: https://github.com/Shamar/Epic.NET/tree/devel/Challenges/Challenge00.DDDSample
[epic-code]: https://github.com/Shamar/Epic.NET "Epic.NET code base on GitHub"
