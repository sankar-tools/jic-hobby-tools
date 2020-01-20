require('./objectX');
const chalk = require('chalk');
const fs = require('fs');

// init logger
var initLog = `Log file initialized\n${Date(Date.now()).toString()}\n`;
fs.writeFileSync(`${_rootDir}/log/temp.log`, initLog);
logger = {}

// ToDo:: __function not returns the calling function names
logger.trace = function(str){
  console.log('\n', __line, ':', __function, '>>', str);
}

// ToDo:: add name of the actual variable to the watch
logger.watch = function(...args){
  var s = [];
  s.push(`\n-------Line:${__line} Fn:${__function} File:${__file}`);
  args.forEach(function(arg){
    s.push(JSON.stringify(arg,null,4));
  });

  console.log(chalk.yellow(s.join('\n')));
}

logger.record = function(...args){
  var s = [];
  s.push(`\n-------Line:${__line} Fn:${__function} File:${__file}`);
  args.forEach(function(arg){
    s.push(JSON.stringify(arg,null,4));
  });

  fs.appendFileSync(`${_rootDir}/log/temp.log`, s.join('\n'));
}
module.exports = logger;
