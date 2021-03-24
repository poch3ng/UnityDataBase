
<?php 
	require("dbconnect.php");

    $query = "SELECT * FROM `scoreboard` ORDER by `score` DESC LIMIT 5";
    $result = mysqli_query($con, $query) or die('Query failed: ' . mysql_error());
 
    $num_results = mysqli_num_rows($result);  
 
    for($i = 0; $i < $num_results; $i++)
    {
         $row = mysqli_fetch_array($result);
         echo $row['username'] . "\t" . $row['score'] . "\n";
    }
 ?>