module.exports = function (context, myTimer) {
    var timeStamp = new Date().toISOString();

    if (myTimer.isPastDue) {
        context.log('JavaScript is running late!');
    }

    var toBeQed = myQueueItem();
    toBeQed.time = timeStamp;
    context.bindings.myQueueItem = toBeQed;

    context.log('JavaScript timer trigger function ran!', timeStamp);

    context.done();
};

function myQueueItem() {
    return {
        msg: "http://urlnextdoor.com/ai/design-layout/images/sample-png.png",
        time: "time goes here"
    }
}