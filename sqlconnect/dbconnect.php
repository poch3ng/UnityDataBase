<?php

	$con = mysqli_connect('localhost', 'root', '', 'game');

	//check that connection happened
	if (mysqli_connect_errno())
	{
		echo "1: Connection failed"; //error code #1 = connection failed
		exit();
	}
	
?>