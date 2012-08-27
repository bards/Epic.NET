---
layout: post
title: Welcome changes!
---

Hi guys! We are ready to announce a few changes in the Epic's directions.

First, we moved to .NET 4. I'd like to stick to 3.5 but we would need to backport
some classes that we want to use. And, BTW, variant generic interfaces are so cool!
In the process we updated the documentation, adding the long-awaited API reference.

But this is neither the only nor the major change that we did. 

We completely refactored the Epic.Linq project by splitting it into two new projects:
**Epic.Query** and **Epic.Query.Linq**. In Epic.Query you find the relational algebra
and the plumbing for all the query systems that Epic will support.
On the other hand, Epic.Query.Linq becomes the Epic framework for Linq based repositories.

However we are working on an alternative to Linq too: **Epic.Query.Object**.
The idea of a Specification-based QueryObject is not original but we tried it in
a real world application where an important requirement of the domain model
was to track the search that the user did during a his own activity down to the
in the orders they send.  
Such searches had an important role in the domain consistency: they were 
*customer needs* to satisfy. 

Finally, we introduced a brand-new module in Epic, the Prelude.
**Epic.Prelude** contains a set of general purpose models and tools borrowed 
from both mathematics and experience. We consider them so general and well written
that there's no reason to write your own. Thus, if you are using Epic for 
your application, you can decide to adopt it also as a foundational domain
(note that the Epic.NET's licence still applies).

This is a major philosophical change in the Epic's vision, becouse we provide
a set of models that you can depends on. However a bit of pragmatism moved this 
choice.


