---
layout: post
title: Stupidity considered harmful
description: I'm not Edsger Dijkstra. Neither are you. Live with it.
public: false
author: giacomo
---

**DISCLAIMER** With this post, I join the "[IWannaBeDijkstra club][considered-harmful]", with the hope to stop such shame.  
I'm not  [Edsger Dijkstra][dijkstra]. Neither are you. Live with it. ;-)

What's harmful, now?
-------------------------------
Recently, I've been caught by an interesting debate with a few **very smart** guys: [Arialdo Martini][arialdo], [Dan North][dan], [Alberto Brandolini][alberto] and [Uberto Barbini][uberto] among others.

Everything started with a [tweet][twt1] about [code coverage considered harmful][ccch] and a (casually) related thread started by Fabio Sogni in the [italian DDD mailing list][ddd-it], that touched topics like the TDD definition, the meaning of code coverage, how they related to DDD and much more.

Now, in these days, [code coverage is considered harmful][ccch].

If you carefully read the Pearson's article, you will rapidly understand that all the issues proposed are related to either poor developers or poor architects/team leaders. Indeed, today, even [Pearson changed his mind][pchm].  
But why smart people get trapped with these sort of dumb, absolute, assertions?

Buzzword Driven Development
------------------------------------------
The problem is the need of **buzzwords**, to exploit [a bug of market][information-asymmetry].

A long time ago, far, far away, in a world dominated by [monsters][sc] named [Rose][rose] and [RUP][rup], a few fellow programmers, tried to address a **weird**, **over-complicated** development process with a few **well defined** practices from good sense. They lost some battle, but they **won** the war.   

Now... Agile is the new RUP.

But back in those days, the most disruptive innovation was TDD: Test Driven **Development**.  
Designed to avoid **needless abstractions**, TDD simply demanded **writing tests before**.  
**First**. Before everything else. Even design had to emerge from tests and refactorings. 

Indeed, one of our heros once stated:

<blockquote>The act of writing a unit test is more an act of design than of verification.</blockquote>

Unfortunately, during the evolution from [A.S.S.][ass] a [Super Senior Agile Software Craftsman][craftmanship], [he forgot][pragmatics] the [why][swwhy].

Don't get me wrong: [the Pragmatics of TDD][pragmatics] is a valuable article, very useful and smart.

The only bug there is the title: they are not pragmatics of TDD, they are pragmatics of **TDC**.  
(the only... apart setters! :-D)

TDC, what?
----------------
No, it's not a new buzzword, just an acronym.

Robert Martin states:

<blockquote>TDD is a discipline for programmers like double-entry bookkeeping is for accountants or sterile procedure is for surgeons.</blockquote>

Right. It's the discipline of writing tests before design, to avoid any needless abstraction. Plain simple!

Such discipline is required in some cases and it's not in others. And indeed he states that he doesn't practice TDD every times. He knows that he doesn't need that tool and he avoids its use.

The point, however, is that you cannot partially apply TDD. TDD is for whole software artifacts, not just whole classes or methods.
Indeed, the design can have a single source: either tests (strictly avoiding needless abstractions) or something else (when the needless abstractions are not your worse enemy).

Thus Martin is talking about the pragmatics of TDC: Test Driven **Coding**.  
A different and extremely valuable tool!

But it's incredible that he didn't realized the **deep** difference. 

Deep difference?
------------------------
TDC is a different thing from TDD. 

You draft the design and **then** you start with Green-Red-Refactor iteractions. 
Perfect. Very useful!

But, you can't call this practice TDD, or you lose the proper term to denote the original tool. 

And TDD (the true one) is a valuable tool, whenever your major problem is to prevent needless abstractions.

That, let me say, is quite rare! TDD, is useful in **rare** cases, but when useful, it's **strategic**!

TDC is a totally different beast, useful in much more common scenarios: **tests drive just the coding**.  
Some coding, at least. And this is perfectly fine. TDC **can** be partially applied to any software component.

Unfortunatly, most of those who claim to do TDD, do TDC instead. But they don't want to be blamed as "casual testers", thus they replace a letter in their resumes and their corporate brochures.  
It's not lying... it's marketing, stupid!

But marketing is not for poor programmers like me, that despite manifestos, have to get the job done properly. I need a **precise** technical language to work with.

For example, those who state that TDD is compatible with DDD, probably haven't ever done any of the two.

DDD is compatible with TDC (or, if you wanna use a cooler buzzword, it is compatible with [Outside-In TDD][oitdd]).

Back to code coverage
--------------------------------
Is code coverage harmful, or not?

Guys, **it's a tool**! A set of tools, actually.

Thus:

- if you are doing TDD, a **full** code coverage is a useful **development** tool: if your CI breaks when you push uncovered code, you know that an hated, needless abstraction has poisoned your code.  
  If the converse isn't true for your company, **you should change your hiring techniques**.
- if you are doing TDC, **sometimes** it's useful too: for example when you have to code **higher level abstractions** or **valuable core domains**. Having the **CI that breaks on partial code coverage** works as a sort of [sword of Damocles][sod] that forces developers to carefully review code.  
  Again, if such expensive reviews do not provide the value what they costs, **you should change your hiring techniques**.
- if you are doing TDC and you don't need the quality that comes from such reviews, **you should not measure any kind of coverage**!

A few things worth noting here:

- aiming for high coverage (97%, 98%, 99%...) is a pointless waste of money.
- a full (100%) coverage can just ensure a **minimal** and **unmeasured** quality, not perfection. That's obvious but tons of people complains about the bugs that full coverage can't detect.  
  So let me say this loudly: **you still need testers and a brain!**

Stupidity considered harmful
---------------------------------------
Stupidity **is** harmful. Like guns.  
And [like guns][nra], stupidity feeds tons of people.

Man, you can love your tools. But if you **marry** a tool, any tool, you are a stupid.  
You should not be in the position of taking decisions.

Thus, if you always use TDD (or DDD or TDC or code coverage or anything else) despite of the project's requirements, you are a dangerous mono-state automa.

Specularly, if you refuse TDD (or DDD or TDC or code coverage or anything else) despite the actual value that such tool would provide in your specific case, you are wasting money just to hide your ignorance.

Still, you are not the disease, you are the symptom.  
What is harmful here, is the **stupidity** of those who hired you, recruiting by **hyped buzzwords**.


[considered-harmful]: http://en.wikipedia.org/wiki/Considered_harmful
[dijkstra]: http://en.wikipedia.org/wiki/Edsger_Dijkstra
[dan]: http://dannorth.net/blog/
[arialdo]: http://arialdomartini.wordpress.com/
[alberto]: http://ziobrando.blogspot.it/
[uberto]: http://blog.gama-soft.com/
[twt1]: https://twitter.com/arialdomartini/status/324117847741710336
[ccch]: http://adiws.blogspot.it/2012/04/code-coverage-considered-harmful.html
[ddd-it]: http://it.groups.yahoo.com/group/DDD-IT/message/587
[pchm]: http://adiws.blogspot.it/2012/04/code-coverage-considered-harmful.html?showComment=1366239087530#c57726293217936925
[information-asymmetry]:http://en.wikipedia.org/wiki/Information_asymmetry
[sc]: http://en.wikipedia.org/wiki/Between_Scylla_and_Charybdis
[rose]: http://www-03.ibm.com/software/products/us/en/ratirosefami
[rup]: http://www-01.ibm.com/software/rational/rup/
[ass]: http://www.agilecertificationnow.info/
[oitdd]: http://blog.ploeh.dk/2013/03/04/outside-in-tdd-versus-ddd/
[swwhy]: http://www.startwithwhy.com/
[craftmanship]: http://manifesto.softwarecraftsmanship.org/
[pragmatics]: http://blog.8thlight.com/uncle-bob/2013/03/06/ThePragmaticsOfTDD.html
[sod]: http://en.wikipedia.org/wiki/Damocles#Sword_of_Damocles
[nra]: http://home.nra.org/
