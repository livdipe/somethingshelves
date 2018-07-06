理解&
用法1 将具名函数转换成lambda
    Enum.map([:a, :b, :c], fn a -> Atom.to_string(a) end)
    等同于:
    Enum.map([:a, :b, :c], &Atom.to_string/1)
用法2
    Enum.map([1, 2, 3], fn i -> i * 2 end)
    等同于:
    Enum.map([1, 2, 3], &(&1 * 2))
用法3 生成List或Tuple
    l = &[&1, &2]
    #=> [1, 2]
    t = &{&1, &2}
    #=> {1, 2}
用法4
    fn = &(&1 + &2 + &3)
    fn.(1, 2, 3)
    #=> 6
例子:
    take_five = &Enum.take(&1, 5)
    take_five.(1..100)
    #=> [1, 2, 3, 4, 5]

    first_elem = &elem(&1, 0)
    first_elem.({1, 2, 3})
    #=> 1

关于并行的例子:
    https://gist.github.com/mmmries/cd84b0d6008f58b83d95

