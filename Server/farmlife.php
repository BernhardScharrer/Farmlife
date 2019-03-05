<?php

header('Content-Type: application/json');

include_once 'database.php';

$json = json_decode($_GET['json']);

$db = connectDB();

if (isset($json)) {

    $login = $json->login;

    $username = $login->username;
    $password = $login->password;

    $rs_user = $db->query("SELECT salt, password FROM user WHERE username='".$username."';");

    if ($rs_user->num_rows === 1) {
        $data = $rs_user->fetch_array();
        $salt = $data['salt'];
        $hash = md5($salt.$password.$salt);

        if ($hash === $data['password']) {

            $db->close();
            proceed($username);

        } else {
		echo json_encode(array("auth"=>false));
	}

    } else {
	    echo json_encode(array("auth"=>false));
    }


} else {
    $db->close();
}

function proceed($username) {



}

//CREATE TABLE IF NOT EXISTS user (user_id INT NOT NULL AUTO_INCREMENT, username VARCHAR(30), password VARCHAR(100), salt VARCHAR(5), PRIMARY KEY(user_id));

