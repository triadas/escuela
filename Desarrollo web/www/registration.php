<?php  include "db.php" ?>
<!DOCTYPE html>
<html lang="ru" dir="ltr">
  <head>
    <meta charset="utf-8">
    <meta name="website" content="some attempt to make site correctly">
    <meta name="author" content="Sueno">
    <meta name="keywords" content="learn html programming as calm boy">
    <meta name="viewport" content="width=device-scale; initial-scale=1.0">
    <title>My website</title>
    <link rel="stylesheet" href="registration.css">
  </head>
  <body class="body">
    <header class="">
      <nav class="nav">
        <ul id="nav">
          <li><a href="index.php">GHJ<a></li>
          <li><a href="about.php">о нас</a></li>
          <li><a href="login.php">чат</a></li>
          <li><a href="registration.php">донаты</a></li>
        </ul>
      </nav>
    </header>
    <main>
      <article>
        <section>
          <form class="box" action="<?php htmlspecialchars($_SERVER["PHP_SELF"]) ?>" method="post">
            <h2>Регистрация</h2>
            <input type="text" name="username" value="" placeholder="ваш логин"><br>
            <input type="password" name="password" value="" placeholder="ваш пароль"><br>
            <input type="submit" name="submit" value="зарегистрироваться"><br>
            <p style="text-align: center;">
              <?php

                  if($_SERVER["REQUEST_METHOD"] == "POST"){

                      $username = filter_input(INPUT_POST, "username", FILTER_SANITIZE_SPECIAL_CHARS);
                      $password = filter_input(INPUT_POST, "password", FILTER_SANITIZE_SPECIAL_CHARS);

                      if(empty($username)){
                          echo"Пожалуйста, введите логин";
                      }
                      elseif(empty($password)){
                          echo"Пожалуйста, введите пароль";
                      }
                      else{
                          $hash = password_hash($password, PASSWORD_DEFAULT);
                          $sql = "INSERT INTO users (user, password) VALUES ('$username', '$password')";

                          try{
                              mysqli_query($conn, $sql);
                              echo"You are now registered!";
                          }
                          catch(mysqli_sql_exception){
                              echo"имя занято";
                          }

                          }
                      }
              ?>
          </p>
          <a href="login.php" id="reg">войти</a><br>
          </form>
        </section>
      </article>
    </main>
    <footer><p>© 2024 Название Компании Все права защищены.</p></footer>
    <script type="text/javascript" src="script.js"></script>
  </body>
</html>

<?php mysqli_close($conn); ?>
