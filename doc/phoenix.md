
查看路由: `mix phx.routes`

查看phoenix版本: `mix phx.new --version`

```
timer.ex (EnchufeWeb.Endpoint.broadcastd)
=>
TimerChannel.ex (push socket)
=>
socket.js (getElementById, innerHTML)
=>
index.html.eex
```

Array input https://medium.com/@chipdean/phoenix-array-input-field-implementatjion-7ec0fe0949d

 http://blog.plataformatec.com.br/2016/09/dynamic-forms-with-phoenix/

## 发布

使用Heroku发布phoenix https://hexdocs.pm/phoenix/heroku.html

使用的命令

```bash
git add somefile
git commit -m "modify some file"
git push heroku master

mix phx.gen.secret

heroku run "POOL_SIZE=2 iex -S mix"
heroku run "POOL_SIZE=2 mix ecto.migrate"
heroku logs # use --tail if you wait to tail them

```

`mix phx.gen.html Questions Question questions question:string options:array:string answer:string`