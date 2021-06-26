# HtmlReader

## Reads Html

Wrapper for reading html reader.

### E.g.

#### Say I have this html...

```html
<html><head><title>this is the title</title><script>window.someVariable = \"some variable\"; </script></head><body>this is my html body</body></html>
```

#### and I would like to fetch the title. Here's how I would try and go about it:

```c#

var reader = new Reader("<html><head><title>this is the title</title><script>window.someVariable = \"some variable\"; </script></head><body>this is my html body</body></html>");

var title = reader.Text("//title");
```

I expect the title variable should have the value `this is the title`.

