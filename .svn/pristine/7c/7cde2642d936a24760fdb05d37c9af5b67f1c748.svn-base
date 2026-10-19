// JavaScript Document

var BrowserCodeName = navigator.appCodeName;
var BrowserName = navigator.appName;
var BrowserVersion = navigator.appVersion;
var Browser = {
  Version: function() {
	var version = 999; // we assume a sane browser
	if (navigator.appVersion.indexOf("MSIE") != -1)
	  // bah, IE again, lets downgrade version number
	  version = parseFloat(navigator.appVersion.split("MSIE")[1]);
	return version;
  }
}

// Date //

var now = new Date();
var todayDate = now.getDate();
var todayMonth = now.getMonth();
todayMonth++;
var todayYear = now.getFullYear();	
var sysdate = (todayMonth + "/" + todayDate + "/" + todayYear);	

var dtCh = "/";
var minYear = 1900;
var maxYear = 2100;

function IsDate(dtStr) {
	var daysInMonth = DaysArray(12)
	var pos1=dtStr.indexOf(dtCh)
	var pos2=dtStr.indexOf(dtCh,pos1+1)
	var strMonth=dtStr.substring(0,pos1)
	var strDay=dtStr.substring(pos1+1,pos2)
	var strYear=dtStr.substring(pos2+1)
	strYr=strYear
	if (strDay.charAt(0)=="0" && strDay.length>1) strDay=strDay.substring(1)
	if (strMonth.charAt(0)=="0" && strMonth.length>1) strMonth=strMonth.substring(1)
	for (var i = 1; i <= 3; i++) {
		if (strYr.charAt(0)=="0" && strYr.length>1) strYr=strYr.substring(1)
	}
	month=parseInt(strMonth)
	day=parseInt(strDay)
	year=parseInt(strYr)
	if (pos1==-1 || pos2==-1){
		alert("The date format should be : mm/dd/yyyy")
		return false
	}
	if (strMonth.length<1 || month<1 || month>12){
		alert("Please enter a valid month")
		return false
	}
	if (strDay.length<1 || day<1 || day>31 || (month==2 && day>daysInFebruary(year)) || day > daysInMonth[month]){
		alert("Please enter a valid day")
		return false
	}
	if (strYear.length != 4 || year==0 || year<minYear || year>maxYear){
		alert("Please enter a valid 4 digit year between "+minYear+" and "+maxYear)
		return false
	}
	if (dtStr.indexOf(dtCh,pos2+1)!=-1 || isInteger(stripCharsInBag(dtStr, dtCh))==false){
		alert("Please enter a valid date")
		return false
	}
	return true
}

function CurrentDate() {
	var d = new Date();
	var curr_date = getDate();
	var curr_month = d.getMonth();
	curr_month++;
	var curr_year = d.getFullYear();
	var sysdate = (curr_month + "/" + curr_date + "/" + curr_year);
	document.write(curr_month + "/" + curr_date + "/" + curr_year);
}

function DaysBetween(date1,date2) {
	
	if (date1.indexOf("-") != -1){ 
		date1 = date1.split("-"); 
	}else if (date1.indexOf("/") != -1){ 
		date1 = date1.split("/"); 
	}else{ 
		return 0; 
	}
	
	if (date2.indexOf("-") != -1){ 
		date2 = date2.split("-"); 
	}else if (date2.indexOf("/") != -1){
		date2 = date2.split("/"); 
	}else{
		return 0; 
	}
	
	if (parseInt(date1[0], 10) >= 1000){
		var sDate = new Date(date1[0]+"/"+date1[1]+"/"+date1[2]);
	}else if (parseInt(date1[2], 10) >= 1000){
		var sDate = new Date(date1[2]+"/"+date1[0]+"/"+date1[1]);
	}else{
		return 0;
	}
	
	if (parseInt(date2[0], 10) >= 1000){
		var eDate = new Date(date2[0]+"/"+date2[1]+"/"+date2[2]);
	}else if (parseInt(date2[2], 10) >= 1000){
		var eDate = new Date(date2[2]+"/"+date2[0]+"/"+date2[1]);
	}else{
		return 0;
	}
	
	var one_day = 1000*60*60*24;
	var daysApart = Math.abs(Math.ceil((sDate.getTime()-eDate.getTime())/one_day));
	return daysApart;
}

function MonthsBetween(date1,date2) {
	var d1 = new Date(date1);
	var d1Date = d1.getDate();
	var d1Months = d1.getMonth();
	var d1Year = d1.getFullYear();
	
	var d2 = new Date(date2);
	var d2Date = d2.getDate();
	var d2Months = d2.getMonth();
	var d2Year = d2.getFullYear();
	
	var months1 = d1.getMonth() + (d1.getFullYear() * 12);
	var months2 = d2.getMonth() + (d2.getFullYear() * 12);	
	
	return Math.abs(months1 - months2);
} 

function IsValidDate(PossibleDate) {
	var PDate = new String(PossibleDate);
	var regex = /(^\d{1,2})\/(\d{1,2})\/(\d{4,4})|(^\d{1,2})\/(\d{1,2})\/(\d{2,2})/;

	if (regex.test(PDate)){
		var month = new String(RegExp.$1);
		var day = new String(RegExp.$2);
		var year = new String(RegExp.$3);

		if (month.length == 0){
			month = new String(RegExp.$4);
			day = new String(RegExp.$5);
			year = new String(RegExp.$6);
		}

		var today = new Date();
		var thisYear = new String(today.getFullYear());

		if (year.length == 2){
			if (year > 50 ){
				year = String(Number(thisYear.substring(0,2))-1) + year;
			}else{
				year = thisYear.substring(0,2) + year;
			}
		}
		if (month < 1 || month > 12){ 
			return false; 
		}
		if (day < 1 || day > 31){ 
			return false; 
		}
		if ((month==4 || month==6 || month==9 || month==11) && day > 30){
			return false; 
		}
		if (month == 2){ // check for february 29th
			var isleap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
			if (day > 29 || (day == 29 && !isleap)){
				return false;
			}
		}
		if ((Number(year) < Number(thisYear) - 90) ||
			(Number(year) > Number(thisYear) + 90)){ 
			return false; 
		}

		return true;
	}
	return false;
}

// Check browser version
var isNav4 = false, isNav5 = false, isIE4 = false
var strSeperator = "/"; 
// If you are using any Java validation on the back side you will want to use the / because 
// Java date validations do not recognize the dash as a valid date separator.
var vDateType = 3; // Global value for type of date format
//                1 = mm/dd/yyyy
//                2 = yyyy/dd/mm  (Unable to do date check at this time)
//                3 = dd/mm/yyyy
var vYearType = 4; //Set to 2 or 4 for number of digits in the year for Netscape
var vYearLength = 2; // Set to 4 if you want to force the user to enter 4 digits for the year before validating.
var err = 0; // Set the error code to a default of zero

if(navigator.appName == "Netscape"){
	if (navigator.appVersion < "5") {
		isNav4 = true;
		isNav5 = false;
	}else if (navigator.appVersion > "4"){
		isNav4 = false;
		isNav5 = true;
	}
}else{
	isIE4 = true;
}

function DateFormat(vDateName, vDateValue, e, dateCheck, dateType) {
	vDateType = dateType;
	
	// vDateName = object name
	// vDateValue = value in the field being checked
	// e = event
	// dateCheck 
	// True  = Verify that the vDateValue is a valid date
	// False = Format values being entered into vDateValue only
	// vDateType
	// 1 = mm/dd/yyyy
	// 2 = yyyy/mm/dd
	// 3 = dd/mm/yyyy
	
	//Enter a tilde sign for the first number and you can check the variable information.
	if (vDateValue == "~"){
		alert("AppVersion = "+navigator.appVersion+" \nNav. 4 Version = "+isNav4+" \nNav. 5 Version = "+isNav5+" \nIE Version = "+isIE4+" \nYear Type = "+vYearType+" \nDate Type = "+vDateType+" \nSeparator = "+strSeperator);
		vDateName.value = "";
		vDateName.focus();
		return true;
	}
	
	var whichCode = (window.Event) ? e.which : e.keyCode;
	// Check to see if a seperator is already present.
	// bypass the date if a seperator is present and the length greater than 8
	if (vDateValue.length > 8 && isNav4){
		if ((vDateValue.indexOf("-") >= 1) || (vDateValue.indexOf("/") >= 1))
			return true;
		}
	//Eliminate all the ASCII codes that are not valid
	var alphaCheck = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/-";
	if (alphaCheck.indexOf(vDateValue) >= 1){
		if (isNav4) {
			vDateName.value = "";
			vDateName.focus();
			vDateName.select();
			return false;
		}else{
			vDateName.value = vDateName.value.substr(0, (vDateValue.length-1));
			return false;
		}
	}
	
	if (whichCode == 8) //Ignore the Netscape value for backspace. IE has no value
		return false;
	else{
		//Create numeric string values for 0123456789/
		//The codes provided include both keyboard and keypad values
		var strCheck = '47,48,49,50,51,52,53,54,55,56,57,58,59,95,96,97,98,99,100,101,102,103,104,105';
		if (strCheck.indexOf(whichCode) != -1){
			if (isNav4){
				if (((vDateValue.length < 6 && dateCheck) || (vDateValue.length == 7 && dateCheck)) && (vDateValue.length >=1)){
					alert("Invalid Date\nPlease Re-Enter");
					vDateName.value = "";
					vDateName.focus();
					vDateName.select();
					return false;
				}
				if (vDateValue.length == 6 && dateCheck){
					var mDay = vDateName.value.substr(2,2);
					var mMonth = vDateName.value.substr(0,2);
					var mYear = vDateName.value.substr(4,4)
					//Turn a two digit year into a 4 digit year
					if (mYear.length == 2 && vYearType == 4){
						var mToday = new Date();
						//If the year is greater than 30 years from now use 19, otherwise use 20
						var checkYear = mToday.getFullYear() + 30; 
						var mCheckYear = '20' + mYear;
						if (mCheckYear >= checkYear)
							mYear = '19' + mYear;
						else
							mYear = '20' + mYear;
					}
					var vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
					if (!dateValid(vDateValueCheck)){
						alert("Invalid Date\nPlease Re-Enter");
						vDateName.value = "";
						vDateName.focus();
						vDateName.select();
						return false;
					}
					return true;
				}else{
					// Reformat the date for validation and set date type to a 1
					if (vDateValue.length >= 8  && dateCheck){
						if (vDateType == 1){ // mmddyyyy
							var mDay = vDateName.value.substr(2,2);
							var mMonth = vDateName.value.substr(0,2);
							var mYear = vDateName.value.substr(4,4)
							vDateName.value = mMonth+strSeperator+mDay+strSeperator+mYear;
						}if (vDateType == 2){ // yyyymmdd
							var mYear = vDateName.value.substr(0,4)
							var mMonth = vDateName.value.substr(4,2);
							var mDay = vDateName.value.substr(6,2);
							vDateName.value = mYear+strSeperator+mMonth+strSeperator+mDay;
						}if (vDateType == 3){ // ddmmyyyy
							var mMonth = vDateName.value.substr(2,2);
							var mDay = vDateName.value.substr(0,2);
							var mYear = vDateName.value.substr(4,4)
							vDateName.value = mDay+strSeperator+mMonth+strSeperator+mYear;
						}
						//Create a temporary variable for storing the DateType and change
						//the DateType to a 1 for validation.
						var vDateTypeTemp = vDateType;
						vDateType = 1;
						var vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
						if (!dateValid(vDateValueCheck)){
							alert("Invalid Date\nPlease Re-Enter");
							vDateType = vDateTypeTemp;
							vDateName.value = "";
							vDateName.focus();
							vDateName.select();
							return false;
						}
						vDateType = vDateTypeTemp;
						return true;
					}else{
						if (((vDateValue.length < 8 && dateCheck) || (vDateValue.length == 9 && dateCheck)) && (vDateValue.length >=1)){
							alert("Invalid Date\nPlease Re-Enter");
							vDateName.value = "";
							vDateName.focus();
							vDateName.select();
							return false;
         				}
      				}
   				}
			}else{
				// Non isNav Check
				if (((vDateValue.length < 8 && dateCheck) || (vDateValue.length == 9 && dateCheck)) && (vDateValue.length >=1)){
					alert("Invalid Date\nPlease Re-Enter");
					vDateName.value = "";
					vDateName.focus();
					return true;
				}
				// Reformat date to format that can be validated. mm/dd/yyyy
				if (vDateValue.length >= 8 && dateCheck){
					// Additional date formats can be entered here and parsed out to
					// a valid date format that the validation routine will recognize.
					if (vDateType == 1){ 	// mm/dd/yyyy
						var mMonth = vDateName.value.substr(0,2);
						var mDay = vDateName.value.substr(3,2);
						var mYear = vDateName.value.substr(6,4)
					}
					if (vDateType == 2){	// yyyy/mm/dd
						var mYear = vDateName.value.substr(0,4)
						var mMonth = vDateName.value.substr(5,2);
						var mDay = vDateName.value.substr(8,2);
					}
					if (vDateType == 3){	// dd/mm/yyyy
						var mDay = vDateName.value.substr(0,2);
						var mMonth = vDateName.value.substr(3,2);
						var mYear = vDateName.value.substr(6,4)
					}
					if (vYearLength == 4){
						if (mYear.length < 4){
							alert("Invalid Date\nPlease Re-Enter");
							vDateName.value = "";
							vDateName.focus();
							return true;
   						}
					}
					
					// Create temp. variable for storing the current vDateType
					var vDateTypeTemp = vDateType;
					// Change vDateType to a 1 for standard date format for validation
					// Type will be changed back when validation is completed.
					vDateType = 1;
					// Store reformatted date to new variable for validation.
					var vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
					if (mYear.length == 2 && vYearType == 4 && dateCheck){
						//Turn a two digit year into a 4 digit year
						var mToday = new Date();
						//If the year is greater than 30 years from now use 19, otherwise use 20
						var checkYear = mToday.getFullYear() + 30; 
						var mCheckYear = '20' + mYear;
						if (mCheckYear >= checkYear)
							mYear = '19' + mYear;
						else
							mYear = '20' + mYear;
							vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
							// Store the new value back to the field.  This function will
							// not work with date type of 2 since the year is entered first.
							if (vDateTypeTemp == 1) // mm/dd/yyyy
								vDateName.value = mMonth+strSeperator+mDay+strSeperator+mYear;
							if (vDateTypeTemp == 3) // dd/mm/yyyy
								vDateName.value = mDay+strSeperator+mMonth+strSeperator+mYear;
					} 
					if (!dateValid(vDateValueCheck)){
						alert("Invalid Date\nPlease Re-Enter");
						vDateType = vDateTypeTemp;
						vDateName.value = "";
						vDateName.focus();
						return true;
					}
					vDateType = vDateTypeTemp;
					return true;
				}else{
					if (vDateType == 1){
						if (vDateValue.length == 2){
							vDateName.value = vDateValue+strSeperator;
						}
						if (vDateValue.length == 5){
							vDateName.value = vDateValue+strSeperator;
		   				}
					}
					if (vDateType == 2){
						if (vDateValue.length == 4){
							vDateName.value = vDateValue+strSeperator;
						}
						if (vDateValue.length == 7){
							vDateName.value = vDateValue+strSeperator;
		   				}
					} 
					if (vDateType == 3){
						if (vDateValue.length == 2){
							vDateName.value = vDateValue+strSeperator;
						}
						if (vDateValue.length == 5){
							vDateName.value = vDateValue+strSeperator;
		   				}
					}
					return true;
	   			}
			}
			if (vDateValue.length == 10&& dateCheck){
				if (!dateValid(vDateName)){
					// Un-comment the next line of code for debugging the dateValid() function error messages
					alert("Invalid Date\nPlease Re-Enter");
					vDateName.focus();
					vDateName.select();
		   		}
			}
			return false;
		}else{
			// If the value is not in the string return the string minus the last
			// key entered.
			if (isNav4){
				vDateName.value = "";
				vDateName.focus();
				vDateName.select();
				return false;
			}else{
				vDateName.value = vDateName.value.substr(0, (vDateValue.length-1));
				return false;
         	}
      	}
   	}
}

function dateValid(objName) {
	var strDate;
	var strDateArray;
	var strDay;
	var strMonth;
	var strYear;
	var intday;
	var intMonth;
	var intYear;
	var booFound = false;
	var datefield = objName;
	var strSeparatorArray = new Array("-"," ","/",".");
	var intElementNr;
	// var err = 0;
	var strMonthArray = new Array(12);
	strMonthArray[0] = "Jan";
	strMonthArray[1] = "Feb";
	strMonthArray[2] = "Mar";
	strMonthArray[3] = "Apr";
	strMonthArray[4] = "May";
	strMonthArray[5] = "Jun";
	strMonthArray[6] = "Jul";
	strMonthArray[7] = "Aug";
	strMonthArray[8] = "Sep";
	strMonthArray[9] = "Oct";
	strMonthArray[10] = "Nov";
	strMonthArray[11] = "Dec";
	//strDate = datefield.value;
	strDate = objName;
	if (strDate.length < 1) {
		return true;
	}
	for (intElementNr = 0; intElementNr < strSeparatorArray.length; intElementNr++){
		if (strDate.indexOf(strSeparatorArray[intElementNr]) != -1) {
			strDateArray = strDate.split(strSeparatorArray[intElementNr]);
			if (strDateArray.length != 3){
				err = 1;
				return false;
			}else{
				strDay = strDateArray[0];
				strMonth = strDateArray[1];
				strYear = strDateArray[2];
			}
			booFound = true;
   		}
	}
	if (booFound == false){
		if (strDate.length>5){
			strDay = strDate.substr(0, 2);
			strMonth = strDate.substr(2, 2);
			strYear = strDate.substr(4);
   		}
	}
	//Adjustment for short years entered
	if (strYear.length == 2){
		strYear = '20' + strYear;
	}
	strTemp = strDay;
	strDay = strMonth;
	strMonth = strTemp;
	intday = parseInt(strDay, 10);
	if (isNaN(intday)){
		err = 2;
		return false;
	}
	intMonth = parseInt(strMonth, 10);
	if (isNaN(intMonth)){
		for (i = 0;i<12;i++){
			if (strMonth.toUpperCase() == strMonthArray[i].toUpperCase()){
				intMonth = i+1;
				strMonth = strMonthArray[i];
				i = 12;
   			}
		}
		if (isNaN(intMonth)){
			err = 3;
			return false;
   		}
	}
	intYear = parseInt(strYear, 10);
	if (isNaN(intYear)) {
		err = 4;
		return false;
	}
	if (intMonth>12 || intMonth<1){
		err = 5;
		return false;
	}
	if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31 || intday < 1)){
		err = 6;
		return false;
	}
	if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30 || intday < 1)){
		err = 7;
		return false;
	}
	if (intMonth == 2){
		if (intday < 1){
			err = 8;
			return false;
		}
		if (LeapYear(intYear) == true){
			if (intday > 29){
				err = 9;
				return false;
		   }
		}else{
			if (intday > 28){
				err = 10;
				return false;
      		}
   		}
	}
	return true;
}

function LeapYear(intYear) {
	if (intYear % 100 == 0){
		if (intYear % 400 == 0) { return true; }
	}else{
		if ((intYear % 4) == 0) { return true; }
	}
	return false;
}

// Date //

// Number //

function isInteger(s) {
	var i;
    for (i = 0; i < s.length; i++){   
        // Check that current character is number.
        var c = s.charAt(i);
        if (((c < "0") || (c > "9"))) return false;
    }
    // All characters are numbers.
    return true;
}

// only 0-9, comma, period, and minus sign are valid inputs
// usage: onKeydown="currency(this)"
function Currency1(txt) {
	//var strValue = txt.value;	
	var strValue = txt;
	var count = 0;
	var letter;

	if ((window.event.keyCode == 189) || (window.event.keyCode == 109)){	// if "-"
	    for (var i=0; i < strValue.length; i++){
	  		letter = strValue.charAt(i);
    		if ((letter=="-") && (count<1)){
    			count++;
    			window.event.returnValue = 0;
			}
		}
    }else if ((window.event.keyCode == 190) || (window.event.keyCode == 110)){	// if "."
	    for (var i=0; i < strValue.length; i++){
	  		letter = strValue.charAt(i);
    		if ((letter==".") && (count<1)){
    			count++;
    			window.event.returnValue = 0;
			}
		}
    }else if ( !((window.event.keyCode > 47)&&(window.event.keyCode < 58 )) && // 0-9 not on num key pad
        !((window.event.keyCode > 95)&&(window.event.keyCode < 106)) &&  // 0-9 on num key pad, num lock is on
        (window.event.keyCode != 189) && (window.event.keyCode != 109) && // '-' character
        (window.event.keyCode != 190) && (window.event.keyCode != 110) &&	// period
        (window.event.keyCode != 188) &&	// comma
		(window.event.keyCode != 8) && (window.event.keyCode != 46) &&	 // backspace & delete
	    (window.event.keyCode != 36) && (window.event.keyCode != 35) && 	 // home & end keys
	    (window.event.keyCode != 9)		// tab key
	   	){
        window.event.returnValue = 0;
  	}else if ((window.event.shiftKey == 1) || (window.event.ctrlKey == 1))
        window.event.returnValue = 0;
}

// only 0-9 and period are valid inputs
// usage: onKeydown="currency2(this)"
function Currency2(txt) {
	//var strValue = txt.value;
	var strValue = txt;
	var count = 0;

    if ((window.event.keyCode == 190) || (window.event.keyCode == 110)){	// if "."
	    for (var i=0; i < strValue.length; i++){
	  		var letter = strValue.charAt(i);
    		if ((letter==".") && (count<1)){
    			count++;
    			window.event.returnValue = 0;
			}
		}
    }else if ( !((window.event.keyCode > 47)&&(window.event.keyCode < 58 )) && // 0-9 not on num key pad
        !((window.event.keyCode > 95)&&(window.event.keyCode < 106)) &&  // 0-9 on num key pad, num lock is on
        (window.event.keyCode != 190) && (window.event.keyCode != 110) &&	// period
        (window.event.keyCode != 8) && (window.event.keyCode != 46) &&	 // backspace & delete
	    (window.event.keyCode != 36) && (window.event.keyCode != 35) && 	 // home & end keys
	    (window.event.keyCode != 9)		// tab key
		){
        window.event.returnValue = 0;
  	}else if ((window.event.shiftKey == 1) || (window.event.ctrlKey == 1))
        window.event.returnValue = 0;
}

// only 0-9 are valid inputs
function CheckNo() {
	if ( !((window.event.keyCode > 47)&&(window.event.keyCode < 58 )) && // 0-9 not on num key pad
        !((window.event.keyCode > 95)&&(window.event.keyCode < 106)) &&  // 0-9 on num key pad, num lock is on
        (window.event.keyCode != 8) && (window.event.keyCode != 46) &&	 // backspace & delete
	    (window.event.keyCode != 36) && (window.event.keyCode != 35) && 	 // home & end keys
	    (window.event.keyCode != 9)	&& (window.event.keyCode != 13)	// tab key - enter key
	   	){
        window.event.returnValue = 0;
  	}else if ((window.event.shiftKey == 1) || (window.event.ctrlKey == 1))
        window.event.returnValue = 0;
}

// compute age
function ComputeAge(pBDate) {
	
	var age = 0;
	var noMonths = 0;	
	
	if (pBDate == ''){
		age = 0;
	}else{
		var myDOB = pBDate.split('/');
		var myMonth = myDOB[0];
		var myDate = myDOB[1];
		var myYear = myDOB[2];	
		
		var birthdate = (myMonth + "/" + myDate + "/" + myYear);
		
		if (Date.parse(birthdate) > Date.parse(sysdate)){
			alert('Do not enter future date.');
			age = 0;
		}else{
			noMonths = MonthsBetween(birthdate,sysdate);
			age = parseInt(noMonths/12);
		}
	}
	
	return age;
}

// Number //

// Characters //

function ValidateInput(strValue) {
	if(strValue.match(/([\<])([^\>]{1,})*([\>])/i) != null){
		return false;
	}else{
		return true;
	}
}

function Check() {
	for(i = 0; i < document.forms[0].elements.length; i++){
		if ((document.forms[0].elements[i].type=="text") || (document.forms[0].elements[i].type=="textarea")){
			if (ValidateInput(document.forms[0].elements[i].value)==false){
				return false;
			}
		}		
	}
	return true;
}

function replaceSubstring(inputString, fromString, toString) {
   // Goes through the inputString and replaces every occurrence of fromString with toString
   var temp = inputString;
   var toTheLeft;
   var toTheRight;
   if (fromString == "") {
      return inputString;
   }
   if (toString.indexOf(fromString) == -1) { // If the string being replaced is not a part of the replacement string (normal situation)
      while (temp.indexOf(fromString) != -1) {
         toTheLeft = temp.substring(0, temp.indexOf(fromString));
         toTheRight = temp.substring(temp.indexOf(fromString)+fromString.length, temp.length);
         temp = toTheLeft + toString + toTheRight;
      }
   } else { // String being replaced is part of replacement string (like "+" being replaced with "++") - prevent an infinite loop
      var midStrings = new Array("~", "`", "_", "^", "#");
      var midStringLen = 1;
      var midString = "";
      // Find a string that doesn't exist in the inputString to be used
      // as an "inbetween" string
      while (midString == "") {
         for (var i=0; i < midStrings.length; i++) {
            var tempMidString = "";
            for (var j=0; j < midStringLen; j++) { tempMidString += midStrings[i]; }
            if (fromString.indexOf(tempMidString) == -1) {
               midString = tempMidString;
               i = midStrings.length + 1;
            }
         }
      } // Keep on going until we build an "inbetween" string that doesn't exist
      // Now go through and do two replaces - first, replace the "fromString" with the "inbetween" string
      while (temp.indexOf(fromString) != -1) {
         toTheLeft = temp.substring(0, temp.indexOf(fromString));
         toTheRight = temp.substring(temp.indexOf(fromString)+fromString.length, temp.length);
         temp = toTheLeft + midString + toTheRight;
      }
      // Next, replace the "inbetween" string with the "toString"
      while (temp.indexOf(midString) != -1) {
         toTheLeft = temp.substring(0, temp.indexOf(midString));
         toTheRight = temp.substring(temp.indexOf(midString)+midString.length, temp.length);
         temp = toTheLeft + toString + toTheRight;
      }
   } // Ends the check to see if the string being replaced is part of the replacement string or not
   return temp; // Send the updated string back to the user
} // Ends the "replaceSubstring" function

function CharsOnly() {
	if((window.event.shiftKey) == false){
		if ((window.event.keyCode >= 0) && (window.event.keyCode <= 46)){
		}else if((window.event.keyCode >= 65) && (window.event.keyCode <= 90)){		
		}else{
			window.event.returnValue = 0;
		}
	}else{
		if (window.event.keyCode == 9){
		}else{
			window.event.returnValue = 0;
		}
	}
}

function NumberChar() {
	if((window.event.shiftKey) == false){
		if ((window.event.keyCode >= 65) && (window.event.keyCode <= 90)){
			return true;
		}	
		if((window.event.keyCode >= 48) && (window.event.keyCode <= 57)){
			return true;
		}
		if((window.event.keyCode >= 96) && (window.event.keyCode <= 105)){
			return true;
		}	
		if(window.event.keyCode == 8){
			return true;
		}	
		if(window.event.keyCode == 46){
			return true;
		}	
		if(window.event.keyCode == 189){
			return true;
		}		
		if(window.event.keyCode == 109){
			return true;
		}else{
			return false;
		}
	}else{
		return false;
	}
}

// all keys except comma
// usage: onKeyDown = "noComma(this)"
function noComma(txt) {
	var strValue = txt.value;
	var count = 0;

	if (window.event.keyCode == 188) // comma
  	    window.event.returnValue = 0;
}

// close popup
function Close() {
	window.close();
}

// redirect page
function GoToPage(pPage) {
	window.location = pPage;
}

function SelectAll(fieldname) {
	eval("document.forms[0]."+fieldname+".focus();");
	eval("document.forms[0]."+fieldname+".select();");
}

// count area characters
function CountAreaChars(areaName,counter,limit) {
	if (areaName.value.length > limit)
		areaName.value = areaName.value.substring(0,limit);
	else
		counter.value = limit - areaName.value.length;
}

function checkMaxLength(textBox,e, length)
{    
    var mLen = textBox["MaxLength"];
    if(null==mLen)
    mLen=length;

    var maxLength = parseInt(mLen);
    if(textBox.value.length > maxLength-1){
        if(window.event)//IE
            e.returnValue = false;
        else//Firefox
            e.preventDefault();
    }   
}

// Characters //

function Comma(Num) { //function to add commas to textboxes
    Num += '';
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
    x = Num.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1))
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    return x1 + x2;
} 

function extractNumber(obj, decimalPlaces, allowNegative) {
    var temp = obj.value;
	
    // avoid changing things if already formatted correctly
    var reg0Str = '[0-9]*';
    if (decimalPlaces > 0) {
        reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
    } else if (decimalPlaces < 0) {
        reg0Str += '\\.?[0-9]*';
    }
    reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
    reg0Str = reg0Str + '$';
    var reg0 = new RegExp(reg0Str);
    if (reg0.test(temp)) return true;

    // first replace all non numbers
    var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
    var reg1 = new RegExp(reg1Str, 'g');
    temp = temp.replace(reg1, '');

    if (allowNegative) {
        // replace extra negative
        var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
        var reg2 = /-/g;
        temp = temp.replace(reg2, '');
        if (hasNegative) temp = '-' + temp;
    }
	
    if (decimalPlaces != 0) {
        var reg3 = /\./g;
        var reg3Array = reg3.exec(temp);
        if (reg3Array != null) {
            // keep only first occurrence of .
            //  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
            var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
            reg3Right = reg3Right.replace(reg3, '');
            reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
            temp = temp.substring(0,reg3Array.index) + '.' + reg3Right;
        }
    }
	
    obj.value = temp;
}

function blockNonNumbers(obj, e, allowDecimal, allowNegative) {
    var key;
    var isCtrl = false;
    var keychar;
    var reg;
		
    if(window.event) {
        key = e.keyCode;
        isCtrl = window.event.ctrlKey
    }
    else if(e.which) {
        key = e.which;
        isCtrl = e.ctrlKey;
    }
	
    if (isNaN(key)) return true;
	
    keychar = String.fromCharCode(key);
	
    // check for backspace or delete, or if Ctrl was pressed
    if (key == 8 || isCtrl)
    {
        return true;
    }

    reg = /\d/;
    var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
    var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;
	
    return isFirstN || isFirstD || reg.test(keychar);
} 

function Count(text, long) {
    var maxlength = new Number(long); // Change number to your max length.
    if (text.value.length > maxlength){
        text.value = text.value.substring(0,maxlength);
        alert("Only " + long + " chars.");
    }
}                         

function DoBlur(fld, cls) {
    //fld.className = 'txtInputShort';
    fld.className = cls;
}

function DoFocus(fld, cls) {
    //fld.className = 'txtInputShortFocus';
    fld.className = cls;
    fld.select();
} 

function DisabledEnter(evt) {
    /*
    node.type
    text [TextBox]
    select-one [DropDownList]
    checkbox [CheckBox]
    radio [RadioButton]
    submit [Button]
    */
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.type == "text")) {return false;}
    if ((evt.keyCode == 13) && (node.type == "checkbox")) {return false;}
    if ((evt.keyCode == 13) && (node.type == "radio")) {return false;}
} 

function DisabledBackSpace(evt) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 8) && (node.type == "select-one")) {return false;}            
}

function formatPaCardNumber(input) {
    var val = '' + (+input.value);
    if (val) {
        while (val.length < 6) {
            val = '0' + val;
        }
        input.value = val;
    }
}

//function SelectAllText(input) {
//    //document.execCommand('selectall', null, false)
//    input.focus();
//    input.setSelectionRange(0, input.value.length);
//}

SelectAllText = function (input) {
    var selectionEnd = input.value.length
    if (input.setSelectionRange) {
        input.focus();
        input.setSelectionRange(0, selectionEnd);

    } else if (input.createTextRange) {
        var range = input.createTextRange();
        range.collapse(true);
        range.moveEnd('character', selectionEnd);
        range.moveStart('character', 0);
        range.select();
    }
};

function confirmBackspaceNavigations() {
    // http://stackoverflow.com/a/22949859/2407309
    var backspaceIsPressed = false
    $(document).keydown(function (event) {
        if (event.which == 8) {
            backspaceIsPressed = true
        }
    })
    $(document).keyup(function (event) {
        if (event.which == 8) {
            backspaceIsPressed = false
        }
    })
    $(window).on('beforeunload', function () {
        if (backspaceIsPressed) {
            backspaceIsPressed = false
            return "Are you sure you want to leave this page?"
        }
    })
} // confirmBackspaceNavigations