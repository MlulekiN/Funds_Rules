Feature: Configuring Funds&Rules and adding a Promo

Scenario: The user needs to configure the funds and rules and add a promo
	#step 1
	Given The user has logged in the application
	When User clicks on toolbar menu
	And User clicks on view complete menu
	And User clicks on 'Funds & Rules'
	Then Multiple ID's are displayed.
	#step 2
	When User clicks on the add button
	#And Clicks on the text tab 
	And Clicks on the config id dropdown list until '629 - KPI' is displayed
	And Inputs '629 - KPI'
	And Clicks on the ok button
	And User waits for the page to load
	And User clicks on customer level dropdown list until '5 - Level 5' is displayed
	And User selects on the customer level '5 - Level 5'
	And User selects the sell in period 01/04/2022
	And User clicks on product groups drop down list 
		 