<?php
$servername = "127.0.0.1";
$username = "sakila1";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password,
    $database);
if ($conn->connect_error) {
    die("Database connection failed: " . $conn->connect_error);
}
echo "Databse connected successfully, username " . $username . "<br><br>";

$conn->begin_transaction();

$conn->query("SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

// add 10 actors
for ($i = 0; $i < 2; $i++) {
    $sql = "INSERT INTO actor (first_name, last_name, last_update) VALUES ('ACTOR_NAME', 'SMITH', NOW())";
    echo("Inserting actor " . $i . "<br>");
    $conn->query($sql);
};
$conn->commit();

$conn->close();

?>