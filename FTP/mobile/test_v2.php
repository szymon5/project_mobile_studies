<?php
	require_once "connect.php";

		$conn = new mysqli($host,$db_user,$db_password,$db_name);
		
		if($conn->connect_errno != 0)
		{
			echo "Error: ".$conn->connect_errno;
		}
		else
		{
			$sqlQuery = "select * from Users where u_login = 'szymon' and u_password = 'szy123'";
			if($result = $conn->query($sqlQuery))
			{
				$usersq = $result->num_rows;
				if($userq==1)
				{
					$setLogged = "update Users set IsLogged = true where u_login = szymon";
					$conn->query($setLogged);
					// $IS_LOGGED = "select IsLogged from Users where u_login = 'szymon'";
					// $conn->query($IS_LOGGED);
					// $row = mysqli_fetch_assoc($IS_LOGGED);
					// echo $row['IsLogged'];
				}
			}
			$conn->close();
		}
?>