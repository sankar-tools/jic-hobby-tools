require('./objectX');
const chalk = require('chalk');

error = {}

error.notImplemented = function(str){
  console.log(chalk.redBright('\n',__line, ':', __function, __file, 'Warning: Not Implemented...\n',  JSON.stringify(str)));
}

error.raise = function(ty, str){
  console.log(chalk.redBright('\n',__line, ':', __function, __file, `Error: ${ty}...\n`,  JSON.stringify(str)));
}

module.exports = error;
