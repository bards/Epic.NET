---
layout: post
title: Exceptions are terms of the Ubiquitous Language
description: Exceptions are value-objects that should be carefully designed like any other term learnt from the domain expert.
public: true
author: giacomo
---

In the previous article we have already saw that [exceptions are normal results 
of reliable computations][1]. But [exceptions] are well known element of our
daily life.

The etimology of [exception][2] comes from the latin *excipiō*, 
composition of *ex* and *capiō*. Literally something that "take out" of 
something (a process, a rule, a law and so on).

Since human experience leaves sediment in the languages that traverses, modern 
language designers simply borrowed this concept to denote conditions that move 
the computation out of the desired path.

<a name="edge-cases-back"></a>
In domain driven design, we distill a code model from the language that the 
domain expert talks when he solves the problem.
During the modeling session (or the lesson, from the expert's perspective), 
the modeler asks many questions about the behaviours of the system 
and, as a senior coder, he try to explore [borderline cases][edge-cases-fn]. 

From such analisys, we often get a deeper insight of the model that can either 
confirm or not the previously defined terms. Sometimes it leads to deep 
refactoring (like when you see that a new concepts interact heavily with the 
previously modeled ones), sometimes it can even lead to (almost) restart from 
scratch. But often, borderline cases are either **senseless** or **prohibited** 
(in the context under analisys).

An example from real world
--------------------------
Let consider simple case: a command that registers in an investment proposal 
an order to dismiss a financial instrument that the customer does not own.

[Short selling][short-selling] is a well known practice in financial market, 
but it's senseless when you talk with our own financial advisor. 

Indeed, when I asked to the domain expert how to handle this case he said: 
"it's childishly simple, **going short is not allowed** here!".

What's this, if not an exception thrown at me?

Thus I simply made the expert objection explicit in the model with a class 
named `GoingShortIsNotAllowedException`. Simple enough.

Such an exception is a normal outcome of the advisory process, so we have to
explicitly model it as a normal and **well documented** computational result. 
The application that use the domain 
can prevent that such a situation occurs or not, but the business's invariant is 
nevertheless enforced by the domain. Still any coder that uses the domain has 
to ponder whether to catch such exception (and may be present it to a user) 
or ignore it (turning it in an error that should crash the application itself).
Thus our work is still incomplete. We have to provide more informations to 
the client. What financial instrument has caused such exception? 
From which dossier?

Expressive exceptions
---------------------
Expressive exceptions expose useful properties to the clients.  
They **help the user** a lot, since through a proper UI rappresentation of the 
exception, he can understand why his own request cannot be satisfied.  
In applications used all over the world, expressive exceptions **simplify 
localization and internalization**, since useful properties can be shown 
differently at different latitudes, according to the user culture 
(just like any other value object).  
Moreover they can **halve maintenance costs**, since developers can 
rapidly identify what's happened and why from logs.

A cheap but very useful practise is to throw useful messages with 
exceptions. This is particularly important when an exception can be thrown in 
more than situation. For example, you can get a lot more from a 
`KeyNotFoundException` with a message containing the misspelled key.

[Exception chaining][3] is another important technique that allows clients to 
further understand **why** an exception occurred. 

These look as common sense suggestions, but more often than not, good 
developers under pressure think that they can be faster, agile and leaner 
ignoring exceptional paths. Unfortunatly, this is true only for disposable 
prototypes.   
On applications that will run in production, well designed exceptions 
pay well on long term (unless maintenance fees are your business model).

A final tip
-----------
We all know that a IL knowledge in a resume makes you look like a nerd.

Still, sometimes, it can make your life a lot easier. 

If you occasionally avoid exception chaining and you want to re-throw a caught 
exception, you should remember to use the `throw` keyword without specifying 
the caught exception.

Indeed, there are two distinct IL instructions that throw exceptions (actually 
not only exceptions, but this is off-topic here), namely `throw` and `rethrow`.
While `throw` pops the exception from the stack, **reset its stack trace** and 
throws it to the caller, `rethrow` just [rethrow][rethrow] the exception that 
was caught (it's only allowed within the body of a catch handler). 

Thus in the following CS code you will lose the stacktrace forever, since 
it's compiled to a `throw` instruction:

<script type="syntaxhighlighter" class="brush: csharp">try
{
    // some operation here...
}
catch(GoingShortIsNotAllowedException e)
{
    // some trace, log or wtf...
    throw e;
}</script>

If you really can't wrap an exception that you caught before throwing it
again, remember to `rethrow` it as in the following snippet:

<script type="syntaxhighlighter" class="brush: csharp">try
{
    // some operation here...
}
catch(GoingShortIsNotAllowedException e)
{
    // some trace, log or wtf...
    throw; // this will be compiled to a rethrow IL instruction, preserving stacktrace
}</script>

This simple trick will help you (and your colleagues) a lot.

<div class="footnotes" style="display:block; font-size:small;
padding-top:20px;">
<p>[1 <a name="edge-cases-fn" href="#edge-cases-back">^</a>] This is often what
makes the difference between a junior and a senior modeler: 
while the junior one is fully focused to model rightly the intended business 
behaviour, the senior one always keeps an eye open upon unusual cases. 
Indeed even the domain expert often ignores how many borderline situations he daily 
handles by borrowing from his own experience in the business. But since the 
application will be based on such experience, we have to encapsulate it in the 
domain model, and thus we need to turn that knowledge conscious and explicit.
<br/><br/>
This is a two fold aspect of DDD: it's more than an expensive software 
development process, it's a tool to improve the customer understanding of its 
own business. And believe me, a lot of the customer's business success comes 
from his (almost inconscious) ability to identify such cases and properly 
handle them.</p>

</div>

[edge-cases-fn]: #edge-cases-fn
[1]: epic.tesio.it/2012/12/05/exceptions-are-the-norm.html
[2]: http://en.wiktionary.org/wiki/exception
[short-selling]: http://en.wikipedia.org/wiki/Short_(finance)
[3]: http://en.wikipedia.org/wiki/Exception_chaining
[rethrow]: http://msdn.microsoft.com/en-us/library/system.reflection.emit.opcodes.rethrow(v=vs.100).aspx

