---
layout: post
title: Testing rules (and tools)
public: true
---
Epic has received some interest in the last weeks (probably becouse 
of the [pending bet with Greg Young][bet]). 

As previously stated, we really need new developers, and we'd like
to lower the effort required to start contributing as much as possible.

However, being a challenging long term project, Epic requires a set of 
rules to make its codebase both reliable and maintainable.

[Marco][marco] and I already agreed on such (often subtle but carefully crafted)
coding conventions but we have to document them for newcomers.

Indeed each pull request will be reviewed (and discussed, thanks to the 
wonderful tools that GitHub provides), but it's easier to build them 
correctly at first rather than to fix them later. 

Full code coverage is not enough
--------------------------------
Epic's development is not [test driven][tdd].

Development follows a deep analysis that is shared (and discussed) between 
developers. This helps me (as a [dictator][dictator] :-D) to keep the 
components coherent with the overall vision. 

To keep the framework reliable, we have the released code fully covered by 
**unit** tests. Thus, any pull request missing the required tests can not be
accepted. 
Indeed, to reach a 100% code coverage, we have to review the code more and more 
times, understanding it deeply. These reviews help to early find bugs that
we have left behind.

A full code coverage, however is not enough. 
We have to cover behaviours, not just code!

Conventions...
--------------
To get used to test behaviours instead of code, we designed a 
set of conventions for unit tests.

The fixture's name is that of the class under test followed by "QA" (for 
quality assurance), while the namespace is that of the class itself.

Tests adhere to the [Arrange-Act-Assert][aaa-style] style, and their names 
follow the form **Message_Scenario_Assertion**:

- Message is the method (often a command) that is sent to the class under test.  
- Scenario is a description of the preconditions (tipically a semantical 
description of the arguments).  
- Assertion is a description of the assertion to be expected.  

With such conventions, when we name a test, we have to think about the 
behaviour that it will verify. Moreover, looking at the fixture running, 
we can read about the tested behaviours (and identify forgotten ones) even 
when all the lines have been hit.

...and tools
------------
To ease (and force) such convention we wrote two simple code snippets for
[Visual Studio][vs-snippets] and [MonoDevelop][md-snippets].

A VSI installer is available [here][vsi] for VS users.

Once installed properly, they will be fired typing **test** or **etest** (for 
expected exceptions).

Tests rely on NUnit and Rhino.Mocks (in the version included in the 
[3rdParties][3rdP] directory). To verify the code coverage we use NCover (and 
MonoCov, on Linux).

[bet]: http://tech.groups.yahoo.com/group/domaindrivendesign/message/22288
[marco]: http://www.linkedin.com/in/marcoveglio
[tdd]: http://www.agiledata.org/essays/tdd.html "TDD = Tests drives the development."
[dictator]: http://epic.tesio.it/2011/09/25/governance-and-copyright.html
[aaa-style]: http://c2.com/cgi/wiki?ArrangeActAssert
[vs-snippets]: https://github.com/Shamar/Epic.NET/tree/devel/Snippets/VisualStudio
[md-snippets]: https://github.com/Shamar/Epic.NET/tree/devel/Snippets/MonoDevelop
[vsi]: http://sourceforge.net/projects/epic-net/files/Epic.Snippets.vsi/download
[3rdP]: https://github.com/Shamar/Epic.NET/tree/devel/3rdParties
