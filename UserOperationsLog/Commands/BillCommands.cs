﻿using UserOperationsLog.Domain;
using UserOperationsLog.Domain.Entities;

namespace UserOperationsLog.Commands;

internal class BillCommands(TestDatabase context, UserAccessor userAccessor)
{
	public record CreateBillPositionModel(int Count, decimal Price, Guid PriceListItemId);
	public record CreateBillModel(CreateBillPositionModel[] BillPositions);
	public Guid CreateBill(CreateBillModel model)
	{
		Bill entity = new()
		{
			CreatedAt = DateTime.UtcNow,
			CreatedById = userAccessor.UserId,
			Positions = model.BillPositions.Select(x => new BillPosition()
			{
				Count = x.Count,
				CreatedAt = DateTime.UtcNow,
				Price = x.Price
			}).ToList()
		};
		context.Bills.Add(entity);
		context.SaveChanges();
		return entity.Id;
	}


	public record UpsertBillPositionModel(Guid BillId, Guid Id, int Count, decimal Price, Guid PriceListItemId);
	public Guid UpsertBillPosition(UpsertBillPositionModel model)
	{
		BillPosition billPosition;
		if (model.Id == Guid.Empty)
		{
			billPosition = new()
			{
				CreatedAt = DateTime.UtcNow,
				PriceListItemId = model.PriceListItemId,
				BillId = model.BillId
			};
			context.BillPositions.Add(billPosition);
		}
		else
		{
			billPosition = context.BillPositions.Find(model.Id);
		}
		billPosition.Price = model.Price;
		billPosition.Count = model.Count;

		context.SaveChanges();

		return billPosition.Id;
	}

	public void PayBill(Guid id)
	{
		Bill bill = context.Bills.Find(id);
		bill.PaidById = userAccessor.UserId;
		bill.PaidAt = DateTime.UtcNow;
		context.SaveChanges();
	}
}
