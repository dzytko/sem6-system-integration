<?php
$servername = "127.0.0.1";
$username = "sakila1";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error)
    die("Database connection failed: " . $conn->connect_error);

echo "Databse connected successfully, username " . $username . "<br><br>";
$sql = "UPDATE actor SET first_name = 'CHRIS' WHERE first_name = 'ADAM'";
$conn->query($sql);
echo "Table actor updated";
$sql = "UPDATE actor SET first_name = 'ADAM' WHERE first_name = 'CHRIS'";
$conn->query($sql);
echo "Table actor reverted";

$conn->close();
