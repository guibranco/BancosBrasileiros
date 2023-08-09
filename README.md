# Bancos Brasileiros

This branch only contains the **Merge Tool** (.NET 7.0 Console App) used to merge and generate the data.


---

## Contributing

Here are a step-by-step on how to add new source of data to the merge tool:

- Checkout [MergeTool branch](https://github.com/guibranco/BancosBrasileiros/tree/MergeTool).
- Open VS, VS Code, Rider, or your favourite IDE / Code Editor.
- Load the project (currently it is in **C# .NET 7.0**).
- Add the required URLs to the `Constants.cs` file.
- Add a new enum item in the `Source.cs` file, use the source system acronyms when possible.
- Add a new method in the `Reader.cs` called **Load[NewSystemAcronym]**, this should do all the heavy job of grabbing the information from the remote source.
- Follow the other methods patterns to extract the PDF information from the file if the new source provides a PDF file.
- Implements the data extraction the way you prefer if it is not a PDF file.
- Add the RegExp to the `Patterns.cs` file if you need to use RegExp to extract data.
- Add the new field(s) to `Bank.cs` file.
- In the `Seeder.cs` file, implement the method **Merge[NewSystemAcronym]** to merge the new data with the existing ones. Prefer to filter the data by *ISPB*, then *Document* to check for existing data. Rely on the existing list, **DO NOT ADD** new bank to the list if it is not present with **COMPE, ISPB, Document, and Name at least**. These are mandatory fields, if you have all this information, and you did not find the bank on the existing list, feel free to add it to the list. (Let me know this in the PR comment).
- Call the new methods (**Load[NewSystemAcronym]r** and **Merge[NewSystemAcronym]**) in `AcquireData` method inside `Program.cs` file
- On the `Writer.cs` file, edit the following methods, mapping the new field(s):
  - `SaveCsv`
  - `SaveMarkdown`
  - `SaveSql`
 - Test it 🧪 
 - Commit and submit a PR 🎉

### Testing

- You can run the application locally without submitting any changes to this repository.
- Run how many times you need, it will only generate some files in the output directory inside **result** directory.
  
