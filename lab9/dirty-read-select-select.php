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
//$conn->query("SET TRANSACTION ISOLATION LEVEL REPEATABLE READ");
$conn->query("SET SESSION TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

$conn->begin_transaction();
echo "Actors<br>";
$sql = "SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'ACTOR_NAME'";
$result = $conn->query($sql);
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        echo "id: " . $row["actor_id"] . " - Name: " .
            $row["first_name"] . " " . $row["last_name"] . "<br>";
    }
}
else {
    echo "0 results<br>";
}

echo"<br>";
//sleep(10);

//echo "Actors<br>";
//$sql = "SELECT actor_id, first_name, last_name FROM actor WHERE first_name = 'ACTOR_NAME'";
//$result = $conn->query($sql);
//if ($result->num_rows > 0) {
//    while ($row = $result->fetch_assoc()) {
//        echo "id: " . $row["actor_id"] . " - Name: " .
//            $row["first_name"] . " " . $row["last_name"] . "<br>";
//    }
//}
//else {
//    echo "0 results<br>";
//}


$conn->commit();

$conn->close();
?>