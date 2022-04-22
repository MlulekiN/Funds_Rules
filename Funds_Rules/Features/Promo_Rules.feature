Feature: Configuring Funds&Rules and adding a Promo

Scenario: The user needs to configure the funds and rules and add a promo
	#step 1
	Given The user has logged in the application
	When User clicks on toolbar menu
	And User searches and clicks on 'Funds & Rules'
	Then Multiple ID's are displayed.
	#step 2
	When User clicks on the add button
	And Clicks on the config id dropdown list until '629 - KPI' is displayed
	And Inputs '629 - KPI'
	And Clicks on the ok button
	And User waits for the page to load
	And User clicks on customer level dropdown list until '5 - Level 5' is displayed
	And User selects on the customer level '5 - Level 5'
	And User selects the sell in period "20/04/2022"
	And sell out date "30/04/2022"
	And User clicks on product groups drop down list 
	And User selects the product and clicks the ok button
	And User clicks the save button
	#Then User closes the promo

	#Step 3
	When User clicks on toolbar menu
	And User searches and clicks on 'Promotional actions'
	And User clicks on the add button
	And User clicks on the contractor button
	And Selects the customer level 'Level 3'
	And User clicks on on customer trigger and search id and select the id 'EC86160'
	And User selects sell in start date and sell out date
	And User selects 'General info' and clicks on TPR in 
	And User clicks the save button
	And User select the 'Products' tab
	And User clicks on the product add button
	And User selects id '004' checkbox and clicks the ok button
	And User clicks the save button
	Then User closes the promo

	#step 4
	When User is at the promo navigator
	#step 5
	And User opens the created promo '000USER_AUTOM37220421094130723'
	And clicks the edit button
	And User select the 'Products' tab
	And User select the 'Business Rules' tab

	#step 6
	And User select the 'Workflow' tab
	 

	

	 

		 