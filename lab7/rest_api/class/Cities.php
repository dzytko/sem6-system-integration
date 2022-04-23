<?php

class Cities {
    private $citiesTable = "city";
    public $id;

    public function __construct($db) {
        $this->conn = $db;
    }

    function read() {
        if ($this->id) {
            $stmt = $this->conn->prepare("SELECT * FROM " . $this->citiesTable . " WHERE ID = ?");
            $stmt->bind_param("i", $this->id);
        }
        else {
            $stmt = $this->conn->prepare("SELECT * FROM " . $this->citiesTable);
        }
        $stmt->execute();
        return $stmt->get_result();
    }

    function create($name, $country_code, $district, $population) {
        $stmt = $this->conn->prepare("INSERT INTO " . $this->citiesTable . " (Name, CountryCode, District, Population) VALUES (?, ?, ?, ?)");
        $stmt->bind_param("sssi", $name, $country_code, $district, $population);
        $stmt -> execute();
        return $stmt->error;
    }

    function updateCityById($id, $name, $country_code, $district, $population) {
        $stmt = $this->conn->prepare("UPDATE " . $this->citiesTable . " SET Name = ?, CountryCode = ?, District = ?, Population = ? WHERE ID = ?");
        $stmt->bind_param("sssii", $name, $country_code, $district, $population, $id);
        $stmt -> execute();
        return $stmt->error;
    }

    function deleteById($id) {
        $stmt = $this->conn->prepare("DELETE FROM " . $this->citiesTable . " WHERE ID = ?");
        $stmt->bind_param("s", $id);
        $stmt -> execute();
        return $stmt->error;
    }

}