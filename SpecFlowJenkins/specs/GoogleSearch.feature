Feature: GoogleSearch

@search
Scenario: Search Name
	Given I am on the google search page
	And I have entered 10 in the serach box with enter
	Then the result should contain 10 on the search results page
