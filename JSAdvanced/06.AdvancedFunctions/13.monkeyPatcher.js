function solution(command) {

    const commands = {
        upvote: () => this.upvotes++,
        downvote: () => this.downvotes++,
        score: () => {
            let upvotes = this.upvotes;
            let downvotes = this.downvotes;
            let totalVotes = this.upvotes + this.downvotes;
            let balance = upvotes - downvotes;
            let rating = 'new';

            if (totalVotes > 9 && upvotes > totalVotes * 0.66) {
                rating = 'hot';
            }
            else if (balance >= 0 && totalVotes > 100) {
                rating = 'controversial'
            }
            else if (balance < 0 && totalVotes >= 10) {
                rating = 'unpopular';
            }

            bonusVotes = Math.ceil(Math.max(upvotes, downvotes) * 0.25);

            return totalVotes > 50
                ? [upvotes + bonusVotes, downvotes + bonusVotes, balance, rating]
                : [upvotes, downvotes, balance, rating];
        }
    };

    return commands[command]();
}

let post = {
    id: '3',
    author: 'emil',
    content: 'wazaaaaa',
    upvotes: 100,
    downvotes: 100
};

solution.call(post, 'upvote');
solution.call(post, 'downvote');
let score = solution.call(post, 'score'); // [127, 127, 0, 'controversial']
console.log(score);
for (let i = 0; i < 50; i++) {
    solution.call(post, 'downvote');      // (executed 50 times)
}
score = solution.call(post, 'score');     // [139, 189, -50, 'unpopular']
console.log(score);