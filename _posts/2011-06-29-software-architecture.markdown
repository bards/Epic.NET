---
layout: post
title: Software Architecture
public: true
---
Today I had an interesting meeting with five other different software 
[architects][6]. It was the first of a series of meeting devoted to share the 
different architectural solutions developed in the different teams of our 
company.

Since it was an introductory session, I asked the others how they define the
[software architecture][7] (and thus the role of software architect).

As expected, the definitions were quite different (it is still debated all over
the world, and many architects hate the term), but no one defined the architect
as [overpaid, out of touch developers][1].

Unfortunately, we didn't have the time to find a _syn thesis_, a shared vision
on the topic. May be we will have such a vision by the end of the meetings.

A generic definition
--------------------
My own definition is a bit [generic][2] (and has been changed thanks to the 
others' ones):

> **Architecture** is the structure given to an artifact, to meet **all** the 
> paid requirements.

The type of the artifact has to be related to the software, but it can be more 
than code design or tools' selection, as an efficient development process for 
a specific project or a fast comunication protocol.

Being the structure of the artifact, architecture is very expensive to be
replaced once the artifact has been built: it is important to get it right early.

Thus, architects have to be experienced "hands on" [developers][3], able to 
debug and understand almost any piece of code rapidly, moving smoothly between 
layers, tiers and technologies.  
Such qualities, even if rare, are still not enough.

Indeed, to my money, software architects need a deep experience to be able to 
(in this order):

1. understand people
2. understand requirements
3. give a clear, unifying vision of the artifact that can guide its realization

Understanding people is the most important one becouse developers, project 
manager, stakeholder and customers are all fundamental variables that should 
forge every architectural decision.

Moreover architects should be [responsible][4] and thus leaders able to
explain and convince all others that their decision was the only logical one,
given all the requirements. Indeed if you understand the reasons of your 
decision you can explain them, otherwise you should not be in the position to 
decide.

The second and the third qualities derived from a deep development experience,
are interconnected: an architect should be able to understand **all** the 
**paid** requirements and to produce a **synthesis**.

Such requirements are related to:

* budget
* functionalities
* developers' skills
* personalities
* standardization (NOTE: this is not always a requirement)
* process sustainability
* code maintainability
* software stability
* performances and so on...

Too much for a man
------------------
Getting such important decisions right and early might be too much for a single 
human being.

Indeed, our artifacts are complex and they move all the time! And we are also 
required to be able to change them rapidly and smoothly!

Thus I'm a fan of architectural teams, without any _princeps inter pares_: 
architects should be forced to **always** reach a **shared decision**.

This might seem inefficient at first, but it leads soon to a high level of trust
between the members of the team. Moreover each decision given from such a team
(two people could be enough, it depends on the complexity of the artifact's 
requirements) is based on the different points of view and on the 
different experiences and thus it has more chances to be the right one.

**Synthesis** is a keyword in architecture.

But what about Epic?
--------------------
How all this is related to Epic?

Well, first of all I recently wrote [a chapter][5] of the Epic's manual 
describing its own architecture.

Second, the meeting made me to consider how such architecture fit a specific
set of requirements but not others.

Finally the people involved in the meeting have inspired in various ways the 
ideation of Epic. One of them also developed with me the architectural vision 
behind Epic.Poem (the presentation layer of Epic).  
Thus, if ever Epic will see the light of day, part of the merit will be of 
theirs.

[1]: http://blogs.tedneward.com/2007/09/20/Hard+Questions+About+Architects.aspx "Hard Questions About Architects"
[2]: http://en.wikipedia.org/wiki/Generic_programming "Generic programming"
[3]: http://reprog.wordpress.com/2010/03/21/the-hacker-the-architect-and-the-superhero-three-completely-different-ways-to-be-an-excellent-programmer/ "The hacker, the architect and the superhero: three completely different ways to be an excellent programmer"
[4]: http://www.tesio.it/2010/09/leadership-and-responsibility.html "Leadership and Responsibility"
[5]: http://epic.tesio.it/doc/the_bellis_perennis.html "The bellis perennis"
[6]: http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf "Who needs an architect?"
[7]: http://www.ics.uci.edu/~fielding/pubs/dissertation/software_arch.htm "Software Architecture by Roy T. Fielding"
