<?php 
	require("dbconnect.php");
	
	$username = $_POST["username"];

	// check if user exists
	// Select "Variable" From "Table" where "conditions" 
	$accountCheckQuery = "SELECT username From scoreboard Where username = '" . $username . "';";

	$accountCheck = mysqli_query($con, $accountCheckQuery) or die("2: Name check query failed");

	if (mysqli_num_rows($accountCheck) > 0)
	{
		echo "3: Name already exists";//error code #3 -name exists cannot register
		exit();
	}

	// Add user to the table
	$insertUserQuery = "INSERT INTO scoreboard (username) VALUES ('" . $username . "');";
	mysqli_query($con, $insertUserQuery) or die("4: insert user query failed");//error code #4 - insert user query failed

	echo ("0");


 ?>