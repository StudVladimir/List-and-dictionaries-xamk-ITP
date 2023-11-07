using System.IO;

namespace ListAndDictionaryTests
{
    [TestClass]
    public class UnitTests
    {
        private StringWriter _stringWriter;
        private StringReader _stringReader;

        [TestInitialize]
        public void TestInitialize()
        {
            // Redirect the Console's output stream so we can read it later.
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            // Make sure the contacts list and dictionary are cleared before each test.
            ClearContacts();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // Clean up and reset the Console's output stream after each test.
            _stringWriter.Close();
            Console.SetOut(Console.Out);

            // Optionally, clean up the input stream if you set it during the test.
            if (_stringReader != null)
            {
                _stringReader.Close();
                Console.SetIn(Console.In);
            }
        }

        [TestMethod]
        public void AddContact_WithUniqueEmail_AddsContactToList()
        {
            // Arrange
            _stringReader = new StringReader("John\nDoe\n123456789\njohn.doe@example.com\n");
            Console.SetIn(_stringReader);

            // Act
            ContactManager.AddContact();

            // Assert
            Assert.IsTrue(ContactManager.ContactExists("john.doe@example.com"));
            Assert.AreEqual("Contact added successfully!\r\n", _stringWriter.ToString());
        }

        [TestMethod]
        public void RemoveContact_WithExistingEmail_RemovesContact()
        {
            // Arrange
            AddSampleContact(); // You need to implement this helper method to add a contact for testing.

            // Act
            _stringReader = new StringReader("john.doe@example.com\n");
            Console.SetIn(_stringReader);
            ContactManager.RemoveContact();

            // Assert
            Assert.IsFalse(ContactManager.ContactExists("john.doe@example.com"));
            Assert.AreEqual("Contact removed successfully.\r\n", _stringWriter.ToString());
        }

        [TestMethod]
        public void FindContact_WithExistingEmail_FindsContact()
        {
            // Arrange
            AddSampleContact(); // You need to implement this helper method to add a contact for testing.

            // Act
            _stringReader = new StringReader("john.doe@example.com\n");
            Console.SetIn(_stringReader);
            ContactManager.FindContact();

            // Assert
            string expectedOutput = "Contact found:\r\nName: John Doe, Phone: 123456789, Email: john.doe@example.com\r\n";
            Assert.AreEqual(expectedOutput, _stringWriter.ToString());
        }

        [TestMethod]
        public void DisplayAllContacts_WithContacts_DisplaysContacts()
        {
            // Arrange
            AddSampleContact(); // You need to implement this helper method to add a contact for testing.

            // Act
            DisplayAllContacts();

            // Assert
            string expectedOutput = "\nList of all contacts:\r\nName: John Doe, Phone: 123456789, Email: john.doe@example.com\r\n";
            Assert.AreEqual(expectedOutput, _stringWriter.ToString());
        }

        // Implement the helper method to add a sample contact for testing.
        private void AddSampleContact()
        {
            ContactManager.Contacts.Add(("John", "Doe", "123456789", "john.doe@example.com"));
            ContactManager.EmailToIndexMap.Add("john.doe@example.com", 0);
        }
    }
}