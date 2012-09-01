---
layout: post
title: Looking for niche markets
public: true
---
I am very ambitious.

I'm building a framework that few teams all over the world will adopt.

This will happens for many reasons:

* 95 to 97 percent of the corporate softwares of the "primero mundo" (like my 
  brazilians friends call the rich occident and in crisis) have already be 
  written without it
* big giants like Microsoft, Oracle and IBM need to rise the complexity of 
  software development to sell their products and services
* the framework requires a deep understanding of object oriented programming
  (that despite the hype, isn't yet mainstream)
* the framework requires a deep understanding of domain-driven design "as in 
  the book" (indeed many people are moving from the original methodology to
  others that focus on development details instead of the creative 
  collaboration with a domain expert) 
* Epic.NET scares

I ideated Epic.NET after some year of experience in the development of 
frameworks for the finance sector of the company I'm working on. 
All "my" frameworks share the same strenghts and the same weaknesses: 
they are really powerful, they reduce the development time a lot, they require 
high skills and rigorousness.  

However Epic is different: while some Epic components are designed after 
previous "prototypes" that currently run in production, the overall vision 
(and the code base) are completely new.

So, why did I started such a long journey?

I discussed almost year ago with my collegues about the concept of Epic and we 
agreed that nothing similar is present in the market. 
However, they stated, it was "way too ambitious".

Most of frameworks out of there try to simplify the developer's work with 
general purpose tools. Epic [doesn't][do-not-protect]. It has been designed to 
meet the needs of a few corporate applications with complex business rules.

Time per complexity
-------------------
To better explain what I mean, let's suppose that we can measure the minimal 
complexity of a software development project. I do not mean simply a measure of
the cyclomatic complexity of the running application, but a qualitative evaluation 
that takes into account the complexity of the project too, its history 
and evolution, the changes in the requirements, the refactoring breakthrough
and so on.

Now consider some different development techniques that you have tried in your 
life.

Can you remember how easy was to develop small applications with your brandnew 
VB6 RAD tool? Can you remember how easy was to develop a simple ecommerce with, 
say, Ruby on Rails?

However you can remember what happened that time, when the customer 
required a small change, than another one, and finally you had to rewrite the
application from scratch (and the customer got a new application full of 
untested bugs).

So you've get a team and moved to N-Tiers applications. Your new customer was 
so satisfied of your work that payed another application and another one again. 
Then he asked to make them comunicate. And you had to learn about 
Service Oriented Architectures.

SOA were cool but you started to see how they can overwhelm some applications,
that were cheaper to be written in the previous methodology.

Even if the example is quite dumb, you get the point.

Now, imagine that you can draw a graph with the minimal complexity of a project
on the abscissa and the time required to complete the project with each 
methodology on the ordinate.

Each methodology would draw different curves (and such curves would change 
together from team to team). The lower is the curve, the cheaper is the 
development. In our story, each methodology requires higher skill from the 
previous one. 

At first, the RAD technologies perform best, but after the inflection point a 
small increase of complexity will require a lot more time to invest.
At some point N-Tiers based applications win. However again after some point
the complexity require another approach and the SOAs become cheaper then all 
the previous ones.

![Time required per project complexity qualitative graph](/imgs/posts/2011-08-31-time-complexity.png "Time required per project complexity qualitative graph")

Epic could scare many teams becouse it has a slow, steep learning curve and the 
development will require a deep understanding of the domain [before that the 
architecture itself can be defined][bellis]. Long brainstorming sessions with the domain 
expert are required and only after that the model has been written and tested, 
you can define the technological aspects of the application.

Thus the shape of the curve drawn from Epic on the time/complexity graph 
is quite different from the others. It's far too expensive if your customer just 
needs to write and read a SQL database. However if the complexity is high 
enough, it's the cheapest approach you can adopt (IMHO the DDD curve would be 
similar, but this is quite debated... to my money, a man with an hammer should 
be able to estimate nails).

Where is the corner point?
--------------------------
Hard to say. Epic does not even exist! (yet... :-D)

I can say that the smaller application that we have built with the Epic's 
"prototypes" was a financial risk manager that required almost 200 person-day 
to be completed. Indeed it has been profitable at the very first customer, but 
we have been able to meet the requirements of three other customers in a week 
each (this have been possible since we got the model right at first and the 
customers simply asked for different UIs/services).

My hope is that Epic will halve the effort required.

However the Epic framework targets a niche markets of applications that have an 
high percieved value from the customer point of view (tipically used for their 
core business), complex domains and challenging technological requirements.

[bellis]: http://epic.tesio.it/doc/manual/the_bellis_perennis.html
[do-not-protect]: http://davybrion.com/blog/2009/04/educate-developers-instead-of-protecting-them/ "Educate Developers Instead Of Protecting Them"
