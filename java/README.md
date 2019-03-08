Space-Data-Model-Example
===

|Version|Last Updated|
|---|---|
|14.0.1|March 2019|

About
---
This example code will demonstrate the different approach of modeling your space data.
See [Gigaspaces Documentation](https://docs.gigaspaces.com/sbp/modeling-your-data.html#example-code) for details.


Build
---

Source files ('space-data-model-example' folder) can be located anywhere on your machine.

For build use:

``mvn clean install``
    
Run
---

1. Start XAP using command `./gs-agent.sh`
2. From new terminal change directory to 'space-data-model-example' 
3. Run `runMainJDBC.sh` script for JDBC approach.
4. Run `runEmbeddedOne2One.sh` script for Embedded One-To-One approach.
5. Run `runEmbeddedOne2Many.sh` script for Embedded One-To-Many approach.
6. Run `runNonEmbeddedOne2One.sh` script for Non-Embedded One-To-One approach.
7. Run `runNonEmbeddedOne2Many.sh` script for Non-Embedded One-To-Many approach.

Results
---
If there are no problems then you can see details like this: 
```sh
2019-03-07 17:18:33,348  INFO [com.sun.jini.reggie.GigaRegistrar] - Starting Lookup Service...
2019-03-07 17:18:33,486  INFO [com.sun.jini.reggie.GigaRegistrar] - Started Lookup Service [duration=0.138s, groups=[xap-14.0.1], service-id=163f1242-7ccf-4c18-ac58-3e95918ffb17, locator=jini://127.0.1.1:36083/]
-----#--------  NON-EMBEDDED MODE JDBC Example -------------
writing 2000 books and 1000 Authors
..........
we have 2000 Books in the space
we have 1000 Authors in the space
Query : lastName=Author0 - Found 1 authors - with 2 Books - Query Time[microsecond]:88.168608 books:[0, 1]
Query : lastName=Author1 - Found 1 authors - with 2 Books - Query Time[microsecond]:19.170896 books:[2, 3]
Query : lastName=Author2 - Found 1 authors - with 2 Books - Query Time[microsecond]:19.650447 books:[4, 5]
Query : lastName=Author3 - Found 1 authors - with 2 Books - Query Time[microsecond]:12.580012 books:[6, 7]
Query : lastName=Author4 - Found 1 authors - with 2 Books - Query Time[microsecond]:12.505659 books:[8, 9]
Query : lastName=Author5 - Found 1 authors - with 2 Books - Query Time[microsecond]:10.186647 books:[10, 11]
Query : lastName=Author6 - Found 1 authors - with 2 Books - Query Time[microsecond]:11.021133 books:[12, 13]
Query : lastName=Author7 - Found 1 authors - with 2 Books - Query Time[microsecond]:7.258966 books:[14, 15]
Query : lastName=Author8 - Found 1 authors - with 2 Books - Query Time[microsecond]:6.674507 books:[16, 17]
Query : lastName=Author9 - Found 1 authors - with 2 Books - Query Time[microsecond]:8.555928 books:[18, 19]
```
