const test = require("ava").default;
const gather = require("../src/gather-statistics");

test("returns something truthy", t => {
    const statistics = gather();
    t.truthy(statistics);
});
