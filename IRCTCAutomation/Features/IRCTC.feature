Feature: IRCTC
	As a user I am going to complete assignment for Mysys

@irctc
Scenario Outline: As a user I am entering source and destination codes in irctc website to check whether trains are dispalyed or not
	Given I am on IRCTC login page
	Then I override the pop up in irctc page
	Then I enter source'<src>' and destination'<dest>'codes
	Then I verify trains are dispalyed or not and check specefic train'<trainname>'
	Then I teardown the browser
Examples:
| src | dest | trainname            |
| ERS | ALLP | JAN SHATABDI (02075) |

@irctc
Scenario Outline: As a user I am entering source and destination codes in irctc website to check whether a specefic train is dispalyed or not
	Given I am on IRCTC login page
	Then I override the pop up in irctc page
	Then I enter source'<src>' and destination'<dest>'codes
	Then I verify and check specefic train'<trainname>'
	Then I teardown the browser
Examples:
| src | dest | trainname               |
| ERS | ALLP | MAQ TVC EXPRESS (06603) |

@irctc
Scenario Outline: As a user I am entering train number date source and destination codes in irctc website and checking all stations are dispalyed or not
	Given I am on IRCTC login page
	Then I override the pop up in irctc page
	Then I click on track your train
	Then I enter train number'<trainNumber>'and hit enter
	Then I verify all trains stations'<trainStations>'are dispalyed 
	Then I verify the date'<date>'displated
	Then I teardown the browser
Examples:
| trainNumber | trainStations                   | date   |
| 16307       | KANNUR,TALASSSERY,MAHE,VADAKARA | 24-Aug |

@irctc
Scenario Outline: As a user I am entering train number date source and destination codes in irctc website and checking different available seat options, position of seats and ticket fare for the same
	Given I am on IRCTC login page
	Then I override the pop up in irctc page
	Then I enter source'<src>' and destination'<dest>'codes
	Then I verify and check specefic train'<trainname>'
	Then I teardown the browser
Examples:
| src | dest | trainname               |
| ERS | ALLP | MAQ TVC EXPRESS (06603) |