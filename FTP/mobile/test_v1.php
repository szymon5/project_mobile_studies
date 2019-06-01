<?php
	
	require_once "connect.php";
	
	if(isset($_POST['Login']) && isset($_POST['Password']))
	{
		$_Login = $_POST['Login'];
		$_Password = $_POST['Password'];
		
		$conn = new mysqli($host,$db_user,$db_password,$db_name);
		
		if($conn->connect_errno != 0)
		{
			echo "Error: ".$conn->connect_errno;
		}
		else
		{
			$sqlQuery = "select * from Users where u_login = '$_Login' and u_password = '$_Password'";
			
			if($result = $conn->query($sqlQuery))
			{
				$usersq = $result->num_rows;
				if($userq==1)
				{
					$UserID = "select user_id from Users where u_login = '$_Login' and u_password = '$_Password'";
					$conn->query($UserID);
					$row = mysqli_fetch_assoc($UserID);
					echo $row['user_id'];
				}
				
			}
			$conn->close();
		}
	}
?>