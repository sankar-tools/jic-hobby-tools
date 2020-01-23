'use strict'

const fs = require('fs')
const Path = require('path')
const request = require('request')
// const Axios = require('axios')
// const ProgressBar = require('progress')

// async function downloadImage (url) {
//   const { data, headers } = await Axios({
//     url,
//     method: 'GET',
//     responseType: 'stream'
//   })
//   const totalLength = headers['content-length']
//
//   console.log(`\n\n${url} =>`)
//   const progressBar = new ProgressBar('->[:bar] :percent :etas', {
//       width: 40,
//       complete: '=',
//       incomplete: ' ',
//       renderThrottle: 1,
//       total: parseInt(totalLength)
//     })
//
//   const writer = fs.createWriteStream(generateFilePath(url));
//   data.on('data', (chunk) => progressBar.tick(chunk.length))
//   data.pipe(writer)
// }

function downloadFile(file_url , targetPath){
    var targetPath = generateFilePath(file_url)
    // Save variable to know progress
    var received_bytes = 0;
    var total_bytes = 0;

    var req = request({
        method: 'GET',
        uri: file_url
    });

    var out = fs.createWriteStream(targetPath);
    req.pipe(out);

    req.on('response', function ( data ) {
        // Change the total bytes value to get progress later.
        total_bytes = parseInt(data.headers['content-length' ]);
    });

    req.on('data', function(chunk) {
        // Update the received bytes
        received_bytes += chunk.length;

        showProgress(received_bytes, total_bytes);
    });

    req.on('end', function() {
        console.log("File succesfully downloaded");
    });

    req.on('error', function(err) {
      console.log(err);
    })
}

function showProgress(received,total){
    var percentage = (received * 100) / total;
    console.log(percentage + "% | " + received + " bytes out of " + total + " bytes.");
    // 50% | 50000 bytes received out of 100000 bytes.
}

module.exports = downloadFile;

function generateFilePath(url){
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
