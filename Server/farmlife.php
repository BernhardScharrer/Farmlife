<?php

header('Content-Type: application/json');

include_once 'database.php';

echo json_encode($_POST);

exit(0);

$db = connectDB();

if (isset($_POST['login'])) {

    $login = $_POST['login'];

    $username = $login['username'];
    $password= $login['password'];

    $rs_user = $db->query("SELECT salt FROM user WHERE username='".$username."';");

    if ($rs_user->num_rows === 1) {
        $data = $rs_user->fetch_array();
        $salt = $data['salt'];
        $hash = md5($salt.$password.$salt);

        if ($hash === $rs_user->$data['password']) {

            $db->close();
            proceed($username);

        }

    }


} else {
    $db->close();
}

function proceed($username) {

}

//CREATE TABLE IF NOT EXISTS user (user_id INT NOT NULL AUTO_INCREMENT, username VARCHAR(30), password VARCHAR(100), salt VARCHAR(5), PRIMARY KEY(user_id));

