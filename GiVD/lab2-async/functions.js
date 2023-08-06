const event = new Event('clack')


function conditional(conditional, action1, action2, action3, action4) {
  action1()
  if (conditional) {
    action2()
  } else {
    action3()
  }
  action4()
}

function loop(loopCount, action1, action2, action3, eventTarget) {
  let count = 1
  action1()
  while (count < loopCount) {
    eventTarget.dispatchEvent(event)
    action2(count)
    count += 1
  }
  action3()
}

async function conditionalAsync(conditional, action1, action2, action3, action4) {
  await action1(1, 3)
  if (conditional) {
    await action2(2, 3)
  } else {
    action3(3, 3)
  }
  await action4(4, 3)
}

async function loopAsync(loopCount, action1, action2, action3) {
  let count = 1
  await action1()
  while (count < loopCount) {
    await action2()
    count += 1
  }
  action3()
}
