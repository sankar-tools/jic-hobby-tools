mainConfig = require('./config/main');
__rootDir = __dirname;

logger = require('./utils/logger');
logger.banner(
  "Qricks - GetAll \n\
  Ver: 1.0.0"
);

const fs = require('fs');
const path = require('path');
// var async = require('async');

const lineReader = require('line-reader');

let lineCount = 1;
lineReader.eachLine(mainConfig.input.source, function(line) {
    console.log(`${lineCount}: ${line}`);
    //require('./download')(line);
    // require('./download')(line)
    generateFilePath(line);
    lineCount++;
});

console.log(`'Processed: ${lineCount} items'`)

function generateFilePath(url){
  let urlMain = url.split('://').pop()
  let urlComponents = urlMain.split('/');
  let fileComponents = urlComponents.pop().split('.');
  let fileExt = fileComponents.pop();
  let fileWithoutExt = fileComponents.pop();

  // console.log(urlComponents, fileWithoutExt, fileExt);
  console.log(path.resolve(mainConfig.save.path, ...urlComponents, `${fileWithoutExt}.${fileExt}`), '\n');
}
