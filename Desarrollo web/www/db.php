<?php
  $db_server = "localhost";
  $db_user = "root";
  $db_pass = "Vladfedoseev3333";
  $db_name = "kkkkk";
  $conn = "";

  try{
    $conn = mysqli_connect($db_server, $db_user, $db_pass, $db_name);
  }
  catch(mysqli_sql_exception){
    echo"Could not connect! <br>";
  }
?>
