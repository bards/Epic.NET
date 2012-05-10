---
layout: post
title: Governance and Copyright
---
[Architecture][architecture] is the structure given to an artifact, 
to meet all the paid requirements. 
Thus designing a good [governance model][governance-models] for a software 
project is just an application of of architect's skills.

However it requires more than technical knowledge. Such an artifact requires 
an equilibrium between project management, decision processes and legal issues.

After four weeks of analisys I finally got a syntesis.

I'm a dictator
--------------
For the purpose of this project, I'm a dictator. A [benevolent][bd] one, I hope.

This is the simplest governance model I can design that meet the requirements
of Epic.NET without an overwhelming effort to be maintained.

Indeed the Epic's cost has been estimated to around 400,000 euros 
(of which I almost invested one-tenth till now). I have to keep the 
governance model cheap to concentrate on development.

This should not discourage contributors: I value synthesis a lot and I hate 
to leave a debate before a global consensus has been reached.
Generally speaking, I never impose my own opinion (but I'm quite good to argue).

The GNU Affero General Public License
-------------------------------------
I released Epic as free software because I know that, despite the high 
skills required to contribute, many people around the world can take a strong 
advantage from the framework and thus they will help to complete the 
development. Indeed, when I really need a feature that a proprietary software 
misses, I can just live without it or replace the software entirely.

Free software gives me another option: to patch it myself.
Then I send the patch back to the community. Egoistically. 
I do not want to maintain the patch myself. I want to forget it.

I've done such things more and more times. For fun and for profit.

In some occasion I earned some respect in the communities, that lead me to 
contribute for a while. And again, egoistically: I learnt a lot. 
I could not do my job today without what I learnt in such occasions.

However I'm quite different from Linus Torvalds and Epic is not an operative 
system. Thus I choosed the GNU Affero General Public License to give the
strongest freedom to the end users and to avoid the SaaS loophole.

AGPLv3, indeed, imposes that any application based on Epic.NET will have to be 
available for downloads to all end users as source code (even if it is used 
as a service) and such users will be free to redistribute it. 
Such license leaves me the option to sell linking exceptions to developers of 
proprietary software that would pay for the productivity boost that the 
framework provides.

This is not an option: only Silvio Berlusconi could give away 400,000 euros 
without any plan to return over the investment! :-D

License Agreements
------------------
To keep the dual licensing business model available in the future I collected
the copyright assignments over the work of other contributors.

Developers and architects that want to contribute to Epic's code and 
documentation will have to sign the [Fiduciary License Agreement][fla]
([latex code here][fla-code]).

This agreement is based on the [FSFE's one][fsfe-fla], adapted from Kern 
Sibbald to the needs of [Bacula][bacula-fla] and finally revised with a 
lawyer to be adapted to the italian law.

Filling it out is really quite simple, but you should **read it carefully** 
since it's a enforceable contract. 
If you need a personal copy, please make two copies, otherwise one copy is 
sufficient, then put your name and mailing address on the page 2.

If you are employed and you do Epic.NET work while at work or your employer 
has the rights to your work (often the case), please put your employer's 
information here.

On page 3 you find a description of the right that you assign to the Fiduciary
(me). The term "Software" there is explained in the Subject Matter section.

On page 4, you can simply put "All code and documentation contributed to the 
Epic.NET project" or if you wish to be more specific please do so. For example 
you could write something like:

> All contributions sent to the source code repository hosted at
> [github.com/bards/Epic.NET][bards-repo] by beneﬁciary under 
> the account name *YourUsernameHere* on or before the date of this document.

(Note however, that such statement, will impose that you sigh a the FLA 
again if you change your username or send any patch via mail) 

Finally, on page 5, put the city where you are, the date, and sign it, then 
send one or two copies to me via post (the address is in the contract).

In a future post I could talk of the differences in copyright laws between the 
civil law (in Italy) and the common law (in U.S.A.). It's quite interesting 
since most open source projects reside in the states, and european developers 
like me could learn a lot from talking with an expert lawyer on the matter.
However, I've no such time, now.

Why should I contribute?
------------------------
To my money, you should contribute to Epic.NET if 

1. you need it ready for production as soon as possible
2. you have a long object-oriented programming experience
3. you want to join a small but high skilled [community][credits] of developers 
   and architects
4. you want to add it to your resume.

Of course, when the project will complete and we will have something to sell,
we will find a way to reward contributors (probably by hiring the best ones).

As for companies, those who will pay developers to work with us for 
a significant amount of code, will have a 33% discount over
the commercial license (consider that we are planning to sell linking 
exceptions for 30,000 euros each).

Note however that being a very challenging project, it's an high risk 
investment. **It could fail**. 

Developers that invest their own precious time in Epic should ponder this 
carefully. I always do.


[architecture]: http://epic.tesio.it/2011/06/29/software-architecture.html
[governance-models]: http://www.oss-watch.ac.uk/resources/governanceModels.xml
[bd]: http://www.oss-watch.ac.uk/resources/benevolentdictatorgovernancemodel.xml
[fla]: http://epic.tesio.it/doc/FLA.pdf
[fla-code]: https://gist.github.com/1240610
[fsfe-fla]: http://fsfe.org/projects/ftf/fla.en.html
[bacula-fla]: http://www.bacula.org/en/?page=fla
[credits]: http://epic.tesio.it/credits.html
[bards-repo]: https://github.com/bards/Epic.NET
