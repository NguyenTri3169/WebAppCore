console.log("Hello word123") // in ra màn hình console
/*alert("Hello word123");*/
let name = "Nguyen Van A"
let Name = "Nguyen Van B"
console.log("name: " + name + ", Name: " + Name)
let x = 55
let y = 66
let z
console.log("x: " + x)
console.log("y: " + (y - 2))
console.log(2 + z)
if (1 == 1) {
    let k = 1 // let chỉ có tác dụng trong 1 khối lệnh
    var k1 = 2 // var có tác dụng toàn cục
    console.log("k: " + k) // let
}
console.log("k: " + k1)// var
console.log(x == 55) // true hoặc false
const PI = 3.14 // Không thể thay đổi giá trị của hằng số
/*PI = `3.14159`*/ //biến PI đã được khai báo hằng số trước đó nên không thể gán giá trị mới (báo lỗi)
console.log(`Pi = ${PI}`)
const MercedesG63 = true // true hoặc false
console.log(`MercedesG63 = ${MercedesG63}`)

// Mảng trong JavaScript (Array)
let cars = [1, 2,, 3, 4, 5] // mảng có 5 phần tử ( , là phần tử empty)
console.log(cars[2]) //lay phần tử thứ 2 trong mảng sẽ báo undefined
