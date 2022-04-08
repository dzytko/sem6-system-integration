<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../class/Cities.php';


if ($_SERVER["REQUEST_METHOD"] !== "GET") {
    http_response_code(400);
    echo json_encode(array("message" => "Method not allowed"));
    exit;
}

$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);

$data = json_decode(file_get_contents("php://input"));
$cities->id = (isset($data->id) && $data->id) ? $data->id : '0';
$result = $cities->read();

if ($result->num_rows < 0) {
    http_response_code(404);
    echo json_encode(
        array("message" => "No item found.")
    );
    exit;
}

$cityRecords = array();
while ($city = $result->fetch_assoc()) {
    $cityDetails = array(
        "ID" => $city["ID"],
        "Name" => $city["Name"],
        "CountryCode" => $city["CountryCode"],
        "District" => $city["District"],
        "Population" => $city["Population"]
    );
    array_push($cityRecords, $cityDetails);
}
http_response_code(200);
echo json_encode($cityRecords);
