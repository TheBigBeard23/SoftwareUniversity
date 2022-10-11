function solve() {
  let questions = document.querySelectorAll('section');
  let questionAnswer = {
    'Question #1: Which event occurs when the user clicks on an HTML element?': 'onclick',
    'Question #2: Which function converting JSON to string?': 'JSON.stringify()',
    'Question #3: What is DOM?': 'A programming API for HTML and XML documents'
  }
  let rightAnswers = 0;
  let questionsCounter = 0;

  let buttons = document.querySelectorAll('section ul');
  for (let button of buttons) {
    button.addEventListener('click', next);
  }

  function next(event) {
    if (event.target.classList.contains('answer-text')) {
      let question = questions[questionsCounter].querySelector('.question').textContent.trim();
      let answer = event.target.textContent;

      if (questionAnswer[question] == answer) {
        rightAnswers++;
      }
      questions[questionsCounter].style.display = 'none';
      questionsCounter++;

      if (questionsCounter == Object.keys(questionAnswer).length) {

        document.getElementById('results').style.display = 'block';
        let result = document.querySelector('.results-inner h1');

        if (rightAnswers == Object.keys(questionAnswer).length) {
          result.textContent = 'You are recognized as top JavaScript fan!';
        }
        else {
          result.textContent = `You have ${rightAnswers} right answers`;
        }
        return;
      }
      questions[questionsCounter].style.display = 'block';
    }
  }
}