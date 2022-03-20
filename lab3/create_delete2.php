<?php
$servername = "127.0.0.1";
$username = "sakila2";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error)
    die("Database connection failed: " . $conn->connect_error);

echo "Databse connected successfully, username " . $username . "<br><br>";
$sql = "INSERT INTO ";
$conn->query($sql);
echo "Table actor updated";

$conn->close();
