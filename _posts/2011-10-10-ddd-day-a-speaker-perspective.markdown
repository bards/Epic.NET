---
layout: post
title: DDD Day, a speaker's perspective
public: true
---
I thought a lot about what I listened [saturday at Bologna][ddd-day].
(And yes, my spoken english sucks! What an embarassing situation! :-D)

I appreciated all the sessions that I listened, but to my eyes, Greg's 
and Alberto's ones have been the most interesting.

Indeed, as a DDD pratictioner, I noted that our experience almost overlaps 
(with some small yet relevant differences).
That's quite interesting to me: this means that despite the seven years after
the blue book, DDD is still a research field. We still need to dwelve into the
language we use to describe principles and processes, a language that can drive
our decisions.

The devil in the details
------------------------
I think that most of the differences come from the business perspective that we
have. For example Greg Young is a developer and an entrepreneur, he looks 
things from inside the company that has to develop its own software to 
maximize revenues. His talk about choosing the core domain (at the 
beginning of the BOF session) has been very interesting.  

Alberto Brandolin is a trainer and a coach with an evident, huge experience in
many different development teams. My colleagues agree with me that he told us 
many things that we learnt in the hard way.
It's so true that I could state that his session could be a pre-requisite to 
really understand Epic even if we have never talked about it.

As to me, I'm just an architect in a [software house][ors] that aims to build
high quality software **products** with an high degree of customizability.
And we have to compete with our products in a market full of consultancy firms 
that develop custom **projects**.  
We can't really compete on price, we have to compete on value and costs.

We need a production line
-------------------------
I ideated Epic exactly to be a **domain-driven software factory**.

It was ideated on our experience, to further increase the overall productivity 
(with respect to our current tools, that are already powerful).

Our experience leads to some huge difference in how I look at getters, for 
example. To me they have no smell, if the expert state that an object has the 
quality that they provide (in the bounded context).

When I candidly stated that "adopting CQRS/ES in an application is an 
implementation detail" I was looking to the matter from a different point of 
view than Greg (but, for sure, I didn't expect such a vivid discussion! 
With my **poor**, poor english! It was funny, nevertheless! :-D)

While, according to Greg, one of the core concept of Epic is wrong, he still 
wasn't able to convince me. However I'll contact him as soon as possible to 
explain how I can switch a domain model from CQRS/ES to a simple "state storage" 
(like a sql or nosql db) in different applications without even compiling it 
twice.

Indeed, if he's right, I already lost too much of my precious time! :-D

Should you enjoin DDD?
----------------------
I don't know.

After this wonderfull experience, I can't say if it's safe for a company to 
join the DDD train, right now. I could just suggest to hire some expert like 
Alberto to evaluate the risks and opportunities.

While I think that no money comes without risks, I still see a lot of 
(exciting) research in the field. Indeed what I listened gave me more 
questions than answers.

[ddd-day]: http://ddd-day.it/
[manual]: http://epic.tesio.it/doc/manual.html
[bbp]: http://beyondbulletpoints.com/ "Beyond Bullet Points"
[ors]: http://www.ors.it/ "Operational Research Systems"




