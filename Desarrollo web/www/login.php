<?php  include "db.php" ?>
<?php session_start(); ?>
<!DOCTYPE html>
<html lang="ru" dir="ltr">
  <head>
    <meta charset="utf-8">
    <meta name="website" content="some attempt to make site correctly">
    <meta name="author" content="Sueno">
    <meta name="keywords" content="learn html programming as calm boy">
    <meta name="viewport" content="width=device-scale; initial-scale=1.0">
    <title>My website</title>
    <link rel="stylesheet" href="login.css">
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
            <h2>Вход</h2>
            <input type="text" name="username" value="" placeholder="ваш логин"><br>
            <input type="password" name="password" value="" placeholder="ваш пароль"><br>
            <input type="submit" name="submit" value="войти"><br>
            <p style="text-align: center;">
              <?php
                if (isset($_POST["username"])) {
                    if (!empty($_POST["username"]) && !empty($_POST["password"])) {
                        $sql = 'SELECT * FROM users WHERE user = "' . $_POST["username"] . '"';
                        $result = mysqli_query($conn, $sql);

                        if (mysqli_num_rows($result) > 0) {
                            $user = mysqli_fetch_assoc($result);

                            if ($user["password"] == $_POST["password"]) {
                                $_SESSION["username"] = $_POST["username"];
                                $_SESSION["password"] = $_POST["password"];

                                header("Location: forum.php");
                                exit();
                            } else {
                                echo "Неверный пароль!";
                            }
                        } else {
                            echo "Нет такого пользователя";
                        }
                    } else {
                        echo "Пропущено имя или пароль!";
                    }
                } else {
                    echo "Введите правильное имя пользователя или пароль";
                }
              ?>

          </p>
          <a href="registration.php" id="reg">зарегистрироваться</a><br>
          </form>
        </section>
      </article>
    </main>
    <footer><p>© 2024 Название Компании Все права защищены.</p></footer>
    <script type="text/javascript" src="script.js"></script>
  </body>
</html>

<?php mysqli_close($conn); ?>
