using MinimumMauiProjectExample.Models;
using MinimumMauiProjectExample.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MinimumMauiProjectExample.ViewModels
{
  class ItemsPageViewModel : ViewModelBase
  {

    #region Getters & Setters
    private List<Category>? categoryList;
    public List<Category>? CategoryList
    {
      get { return categoryList; }
      set
      {
        categoryList = value;
        CategoryListByOrder = value;
      }
    }

    private List<Category>? categoryListByOrder;
    public List<Category>? CategoryListByOrder
    {
      get
      {
        if (categoryList == null) return null;
        categoryListByOrder = new List<Category>(CategoryList);
        Category categoryAll = new Category() { Name = "All", Order = -9999 };//Add To List the "All" option
        categoryListByOrder.Add(categoryAll);
        categoryListByOrder = this.categoryListByOrder.OrderBy(o => o.Order).ToList();
        return categoryListByOrder;
      }
      set
      {
        categoryListByOrder = categoryList;
        OnPropertyChanged(nameof(CategoryListByOrder));
      }
    }

    private Category selectedCategory;
    public Category SelectedCategory
    {
      get { return selectedCategory; }
      set
      {
        selectedCategory = value;
        if (value.Name == "All")
        {

           _ = GetAllItems();
        }
        else
        {
           CreateItemsAccordingACategory(value.Name);
        }
        OnPropertyChanged(nameof(SelectedCategory));
      }
    }

    private ObservableCollection<Item>? itemListFiltered;
    public ObservableCollection<Item>? ItemListFiltered
    {
      get { return itemListFiltered; }
      set
      {
        itemListFiltered = value;
        OnPropertyChanged(nameof(ItemListFiltered));
      }
    }

    private string itemToAddName;
    public string ItemToAddName
    {
      get { return itemToAddName; }
      set { itemToAddName = value; }
    }

    private string itemToAddDesciption;
    public string ItemToAddDesciption
    {
      get { return itemToAddDesciption; }
      set { itemToAddDesciption = value; }
    }

    private ObservableCollection<Category> itemToAddCategories;
    public ObservableCollection<Category> ItemToAddCategories
    {
      get { return itemToAddCategories; }
      set
      {
        itemToAddCategories = value;
        OnPropertyChanged(nameof(ItemToAddCategories));
      }
    }

    #endregion

    #region Commands Declaration
    public ICommand DeleteItemCommand { get; }
    public ICommand UpdateCommand { get; }
    public ICommand AddItemCommand { get; }
    #endregion

    #region Constructor

    public ItemsPageViewModel()
    {
      InitializeAsync();
      DeleteItemCommand = new Command<Item>(async (item) => await DeleteItem(item));
      AddItemCommand = new Command(async () => await AddItem());

      if (SelectedCategory !=null) {
        SelectedCategory = CategoryListByOrder[0]; // Select the All option
      }
    }

    private async Task InitializeAsync()
    {
      CategoryList = await AppService.GetInstance().GetCategoriesAsync();
      ItemListFiltered = new ObservableCollection<Item>(await AppService.GetInstance().GetAllItemsAsync());
      ItemToAddCategories = new ObservableCollection<Category>(AppService.GetInstance().GetCategoriesByOrder());
      
    }

    #endregion

    #region Methods/Functions
    private async Task GetAllItems()
    {
      ItemListFiltered = new ObservableCollection<Item>(await AppService.GetInstance().GetAllItemsAsync());
    }

    private void CreateItemsAccordingACategory(string filter)
    {
      ItemListFiltered = new ObservableCollection<Item>(AppService.GetInstance().GetAllItemsAccordingACategory(filter));
    }

    private async Task DeleteItem(Item theItemToDelete)
        {
            bool successed = await AppService.GetInstance().DeleteItemAsync(theItemToDelete);
            if (successed)  {
                ItemListFiltered.Remove(theItemToDelete);
            }
        }

    private async Task AddItem()
    {
      List<Category> categoriesToAdd = ItemToAddCategories.Where(category => category.IsChecked == true).ToList();
      if (categoriesToAdd.Count > 0)
      {
        Item itemToAdd = new Item() { Name = itemToAddName, Description = itemToAddDesciption, Categories = categoriesToAdd };
        bool successed = await AppService.GetInstance().AddItemAsync(itemToAdd);
        if (successed)
        {
          //Reset Category picker. the [0] is for selecting All as default
          SelectedCategory = this.categoryListByOrder.OrderBy(o => o.Order).ToList()[0];
          OnPropertyChanged(nameof(SelectedCategory));
          // The above will also Refresh the List of the Items, Since changing SelectCategory has an  GetAllItems(); inside



          //reseting fields
          ItemToAddName = "";
          OnPropertyChanged(nameof(ItemToAddName));
          ItemToAddDesciption = "";
          OnPropertyChanged(nameof(ItemToAddDesciption));

          ItemToAddCategories.Clear();
          ItemToAddCategories = new ObservableCollection<Category>(AppService.GetInstance().GetCategoriesByOrder());
          foreach (var c in ItemToAddCategories)
            c.IsChecked = false;

          OnPropertyChanged(nameof(ItemToAddCategories));
        }
      }
     
    }
    #endregion
  }
}
