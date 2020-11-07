Feature: taschenRechner
	addieren, subtrahieren  und multiplizieren

@mytag
Scenario: Add two numbers
	Given the first number is '50'
	And the second number is '70'
	When the two numbers are added
	Then the result should be '120'

@mytag
Scenario: Subtrahieren
	Given the first number is '99'
	And the second number is '19'
	When Subtraktion wird gestartet
	Then Ergebnis der Subtraktion sollte '80'

	@mytag
Scenario: Subtrahieren - Falsch
	Given the first number is '99'
	And the second number is '19'
	When Subtraktion wird gestartet
	Then Ergebnis der Subtraktion sollte '33'

	@HighPrioTest
Scenario: Multiplizieren
	Given the first number is '33'
	And the second number is '3'
	When Mulitplikation wird gestartet
	Then Ergebnis der Subtraktion sollte '99'
