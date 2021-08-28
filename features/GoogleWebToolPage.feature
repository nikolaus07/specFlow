Feature: GoogleWebToolPage
	rufe Showcase Google Web Toolkit auf und teste Radio-Button...

@mytag
Scenario: Teste Radio-Button
@googleTag   @webBrowser
Scenario: Click Checkboxes
    When navigate to page: 'http://samples.gwtproject.org/samples/Showcase/Showcase.html#!CwCheckBox'
    Then zeitschleife
    Then Set Checkbox on day: 'Tuesday'
    And Set Checkbox on day: 'Friday'
  

@googleTag    @webBrowser
Scenario: Add and delete rows
    When navigate to page: 'http://samples.gwtproject.org/samples/Showcase/Showcase.html#!CwFlexTable'
    Then Flex Table: "Add a row"
    Then Flex Table: "Add a row"
    Then Flex Table: "Remove a row"
    Then Flex Table: "Remove a row"

@googleTag   @webBrowser
Scenario: Test Radio-btn
    When navigate to page: 'http://samples.gwtproject.org/samples/Showcase/Showcase.html#!CwRadioButton'
    Then Set favorit-sport RB to: "Hockey"
