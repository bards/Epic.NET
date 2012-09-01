---
layout: post
title: A step forward
public: true
---
After two months of hard work, I welcome the 0.2 release of Epic.

I can breathe again. Mountains of work are waiting in the next two steps,
but this release add some value to the project _per se_.

Epic.Core
---------
The Epic.Core project includes the entry point of Epic-based application: 
the [enterprise's organizations][1], that manages the livecycle of the users' 
[working sessions][2].
Through the working session a user can achieve or leave his [roles][3]. 
Each role is a hat that provides access to a set of repositories, domain 
services, responsibility and tools, just like all real roles in any real 
enterprise's organization.

All the code released is well documented and features a full coverage from unit 
tests.

Documentation
-------------
Writing good documentation is hard. Hard and **expensive**.

However you can not predict the cost of building a **reliable** application upon 
an undocumented framework: developers can both misunderstand and misuse the 
API and sometimes they have to debug the internals just to understand why a 
strange exception has been thrown.

The API references generated from source code are extremely useful, 
but they’re only part of the story, and eventually all non-trivial frameworks 
require good documentation that provides an overall vision.

The Epic's target audience are high-skilled developers facing complex 
corporate requirements that can not lose their time looking for help or 
insights: they just want to get the job done and move on.

Moreover Epic is more than a C# library: it is a conceptual framework that was 
born out of some years in domain-driven development, with many errors and a 
few successes.

This posed the problem of a good documentation strategy, beyond the obvious 
unit tests and the XML documentation comments included in the code itself.

After some analysis, I realized that I needed to reach a wide variety of 
developers, each using different tools to read the Epic's manual.
Of course I have to provide both HTML and PDF, but why not CHM or EPUB?

Such consideration lead me to docbook. I'm fluent with XML and XSL and I used 
Docbook before (in previous live, when I was a pure Debianist :-D) but I asked 
myself: what about the other contributors? Docbook is a typical unix tool but
no other windows developer that I know would write more than two page in 
docbook. They would find it convoluted.

Then I've found [Asciidoc][4], a funny python script that translates a simple
textual markup into either HTML or Docbook. It was the _deus ex machina_ that I
needed: it is easy to write and to read (even easier than a wiki), it can 
easily produce HTML for windows users and Docbook for linuxers, so that I can
use my Debian box to build the manual in all the format that I need.

Once I defined the toolchain, I wrote [the first part of the manual][5], 
describing the patterns and practices that Epic advises.

**All comments and feedback are very welcome.**

Note that I'm not a native English speaker: feel free to show me the mistakes!

[1]: http://epic.tesio.it/doc/api/html/T_Epic_IOrganization.htm "Model of the enterprise's organizaton."
[2]: http://epic.tesio.it/doc/api/html/T_Epic_IWorkingSession.htm "A user working session."
[3]: http://epic.tesio.it/doc/manual/bounded_roles.html "Bounded Roles"
[4]: http://www.methods.co.nz/asciidoc/ "AsciiDoc - Text based document generation"
[5]: http://epic.tesio.it/doc/manual/nothing_but_business.html "Epic's manual"
