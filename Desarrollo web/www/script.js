// //conditions
// var i = 7;
//
// if(i < 5){
//   document.write("Number is less then 5.<br>");
// }
// else if(i == 5){
//   document.write("Number is eqal to 5.<br>");
// }
// else {
//   document.write("Number is greater then 5.<br>");
// }
//
// //switch
// function DayName(dayNumber) {
//   switch(dayNumber){
//     case 0:
//       document.write("Sunday.<br>");
//       break;
//     case 1:
//       document.write("Monday.<br>");
//       break;
//     case 2:
//       document.write("Tuerstday.<br>");
//       break;
//     case 3:
//       document.write("Wednesday.<br>");
//       break;
//     case 4:
//       document.write("Saturday.<br>");
//       break;
//     default:
//       document.write("an invalid number.<br>")
//   }
// }
//
// DayName(3);
//
// // objects
// var book = {
//   title: "Five ponds.",
//   author: "Jown Rude",
//   pages: 40,
//   characters: [
//     {
//       name: "Roberta",
//       age: 17,
//       weigth: "52 kg"
//     },
//     {
//       name: "Elizabet",
//       age: 19,
//       weigth: "46 kg"
//     }
//   ]
// }
//
// document.write(book.characters[0].name + " is " + book.characters[0].weigth + ".<br>");
//
// // loops
// // for (var i = 0; i < 10; i++) {
// //   i++;
// // }
// //
// // while(){
// // }
// //
// // do{}while();
//
// // Checking password
// // var error = false;
// // var entry = "";
// // var password = "wordpass";
// // var entryCnt = 0;
// // var entryCntMax = 3;
// // while(entry != password && !error){
// //   if(entryCnt == entryCntMax){
// //     error = true;
// //     break;
// //   }
// //   else{
// //     entry = window.prompt("Enter password, please:");
// //     entryCnt++;
// //   }
// // }
//
// // while(error){
// //   alert("CRACH PAGE!");
// // }
// // alert("You're got it.");
//
// // quiz
// var questions = [
//   {
//     prompt: "Какая самая большая страна в мире?\na) Грузия\nb) Испания\nc) Пидорстан",
//     answer: "b"
//   },
//   {
//     prompt: "Какая самая большая пещера в мире?\na) Лиссабонская пещера\nb) Мюнхенская пещера 'Усопшая дева'\nc) Пещера твоей мамаши",
//     answer: "a"
//   },
//   {
//     prompt: "Кого принято считать основателем современного нацизма?\na) Адольфа Гитлера\nb) Бенито Муссолини\nc) Барака Обаму",
//     answer: "a"
//   }
// ];
//
// var scope = 0;
// for (var i = 0; i < questions.length; i++){
//   var response = window.prompt(questions[i].prompt);
//   if(questions[i].answer == response){
//     alert("Corr");
//     scope++;
//   }
//   else{
//     alert("Incorr");
//   }
// }
//
// if(scope == 0){
//   alert("U're lost, scope: " + scope + "/" + questions.length);
// }
// else{
//   alert("U're won, scope: " + scope + "/" + questions.length);
// }
