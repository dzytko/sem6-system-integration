<?php
$servername = "127.0.0.1";
$username = "sakila1";
$password = "pass";
$database = "sakila";

$conn = new mysqli($servername, $username, $password, $database);
if ($conn->connect_error)
    die("Database connection failed: " . $conn->connect_error);

echo "Databse connected successfully, username " . $username . "<br><br>";
$sql = "INSERT INTO actors (first_name, last_name) VALUES ('name', 'lastname')";
$conn->query($sql);
echo "Table actor added";

$sql = "DELETE FROM actors WHERE name='name'";
$conn->query($sql);
echo "Table actor added";

$conn->close();
