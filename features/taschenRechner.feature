Feature: taschenRechner
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given the first number is '50'
	And the second number is '70'
	When the two numbers are added
	Then the result should be '120'

@mytag
Scenario: Subtrahiere two numbers - Richtig
	Given the first number is '99'
	And the second number is '19'
	When Subtraktion wird gestartet
	Then Ergebnis der Subtraktion sollte '80'

	@mytag
Scenario: Subtrahiere two numbers - Falsch
	Given the first number is '99'
	And the second number is '19'
	When Subtraktion wird gestartet
	Then Ergebnis der Subtraktion sollte '33'
