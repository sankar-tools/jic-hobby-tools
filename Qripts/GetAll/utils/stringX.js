String.prototype.replaceAll = function(search, replacement) {
    var target = this;
    return target.split(search).join(replacement);
};


String.prototype.captalize = function(){
  return this.charAt(0).toUpperCase() + this.slice(1)
}


String.prototype.titleCase = function() {
  return this.toLowerCase().split(' ').map(function(word) {
    return (word.charAt(0).toUpperCase() + word.slice(1));
  }).join(' ');
}

String.prototype.interpolate = function(p) {
  const names = Object.keys(p);
  const vals = Object.values(p);
  return new Function(...names, `return \`${this}\`;`)(...vals);
}

// String.prototype.interpolate = function(p) {
//   return (p.charAt(0).toUpperCase() + word.slice(1));
// }
