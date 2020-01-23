'use strict'

const fs = require('fs')
const Path = require('path')
const request = require('request')
const cliProgress = require('cli-progress');

const bar1 = new cliProgress.SingleBar({}, cliProgress.Presets.shades_classic);

var countDownloded = 0;
var countError = 0;

async function downloadFiles(posts) {
  let count = 0;
  for (let post of posts) {
    await downloadFile(post)
    count ++
  }
  console.log('Async: ' + count);
}

function downloadFile(file_url) {
  var targetPath = generateFilePath(file_url)
  var received_bytes = 0;
  var total_bytes = 0;

  var req = request({
    method: 'GET',
    uri: file_url
  });

  var out = fs.createWriteStream(targetPath);
  req.pipe(out);

  req.on('response', function(data) {
    // Change the total bytes value to get progress later.
    console.log('\n'+file_url)
    total_bytes = parseInt(data.headers['content-length']);
    bar1.start(total_bytes, 0);
  });

  req.on('data', function(chunk) {
    // Update the received bytes
    received_bytes += chunk.length;
    bar1.update(received_bytes);
  });

  req.on('end', function() {
    bar1.stop();
    countDownloded++;
  });

  req.on('error', function(err) {
    console.log(err);
    countError++;
  })
}

module.exports = downloadFiles;

function generateFilePath(url) {
  let urlMain = url.split('://').pop()
  let urlComponents = urlMain.split('/');
  let fileComponents = urlComponents.pop().split('.');
  let fileExt = fileComponents.pop();
  let fileWithoutExt = fileComponents.pop();

  let filePath = mainConfig.save.path;
  if (mainConfig.save.preservePath == true)
    filePath = Path.resolve(mainConfig.save.path, ...urlComponents, );

  var fullPath = Path.resolve(filePath, `${fileWithoutExt}.${fileExt}`);

  for (let num = 0; fs.existsSync(fullPath); num++) {
    fullPath = Path.resolve(filePath, `${fileWithoutExt}_${num}.${fileExt}`);
  }

  return fullPath
}
